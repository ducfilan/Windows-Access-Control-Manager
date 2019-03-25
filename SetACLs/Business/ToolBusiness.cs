using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alphaleonis.Win32.Filesystem;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SetACLs.Const;
using SetACLs.Model;

namespace SetACLs.Business
{
	public class ToolBusiness
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string TemplatePath { get; set; }
		private readonly PermissionManipulator _permissionManipulator;
        public int FolderDepth { get; set; }

        public ToolBusiness()
		{
			_permissionManipulator = new PermissionManipulator();
        }

        public void ExportPermission(string permissionToCheckRootPath, string fileNameFullPath, string domain, string serverIpAddress, IProgress<int> progress)
        {
            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Permission");

                var isHeaderPrinted = false;
                var addedRowsCountToPrint = 0;
                progress?.Report(50);

                var permissionsSubFolders = _permissionManipulator
                    .GetPermissionsSubFolders(permissionToCheckRootPath, domain)
                    .Select((p, i) => new { Index = i + 1, Permissions = p })
                    .ToList();

                var replaceByDomainPart = new DirectoryInfo(permissionToCheckRootPath).Parent?.FullName??string.Empty;

                foreach (var item in permissionsSubFolders)
                {
                    progress?.Report(50 + item.Index * 50 / permissionsSubFolders.Count);

                    var outputServerPath = item.Permissions.Key.Replace(replaceByDomainPart, @"\\" + serverIpAddress);

                    var rowToFillFolderInfo = item.Index + addedRowsCountToPrint + (isHeaderPrinted ? 0 : 1);

                    ws.Cells["A" + rowToFillFolderInfo].Value = outputServerPath;

                    FillFolderSize(ws, "B", rowToFillFolderInfo, item.Permissions.Key);

                    ws.Cells["C" + (item.Index + addedRowsCountToPrint)]
                        .LoadFromCollection(item.Permissions.Value.Select(ToExportInfo), !isHeaderPrinted);
                    addedRowsCountToPrint += item.Permissions.Value.Count() + (isHeaderPrinted ? 0 : 1);

                    isHeaderPrinted = true;
                }
                ws.Cells.AutoFitColumns();

                FormatExcelHeader(ws);
                progress?.Report(100);

                excel.SaveAs(new System.IO.FileInfo(fileNameFullPath));
            }
        }

        public void ExportPermissionByTemplate(string permissionToCheckRootPath, string fileNameFullPath, string domain, string serverIpAddress, IProgress<int> progress)
        {
            var blankTemplateFileName = Properties.Settings.Default.BlankTemplateFileName;
            var templateSheetName = Properties.Settings.Default.TemplateSheetName;

            var userList = new Dictionary<string, int>();

            using (var excel = new ExcelPackage(new System.IO.FileInfo(blankTemplateFileName)))
            {
                var worksheet = excel.Workbook.Worksheets[templateSheetName];

                progress?.Report(50);

                var permissionsSubFolders = _permissionManipulator
                    .GetPermissionsSubFolders(permissionToCheckRootPath, domain, true, false)
                    .Select((p, i) => new { Index = i, Permissions = p })
                    .ToList();

                const int folderStartRow = 3;
                const int accountsListRow = 2;

                var folderBaseCellStyle  = worksheet.Cells["A3"].Style;
                var accountBaseCellStyle = worksheet.Cells["A2"].Style;
                var rightsBaseCellStyle  = worksheet.Cells["B3"].Style;

                var accountsCount = 1;
                var folderMaxDepth = 1;

                foreach (var item in permissionsSubFolders)
                {
                    progress?.Report(50 + item.Index * 50 / permissionsSubFolders.Count);

                    var pathBeginWithRootFolder = item.Permissions.Key.Remove(0, 
                        new DirectoryInfo(permissionToCheckRootPath).Parent?.FullName.Length??0);
                    var folderParts = pathBeginWithRootFolder.Split(new []{ '\\' }, StringSplitOptions.RemoveEmptyEntries);
                    if (folderParts.Length > folderMaxDepth)
                    {
                        worksheet.InsertColumn(folderMaxDepth + 1, folderParts.Length - folderMaxDepth);
                        folderMaxDepth = folderParts.Length;
                    }

                    var folderName = folderParts.Last();
                    var folderCol = folderParts.Length;

                    worksheet.Cells[folderStartRow + item.Index, folderCol].Value = folderName;

                    var permissionsCurrentFolder = item.Permissions.Value.Select(ToExportInfo).ToList();
                    foreach (var permission in permissionsCurrentFolder)
                    {
                        int rightsCol;
                        if (!userList.ContainsKey(permission.Account))
                        {
                            userList.Add(permission.Account, accountsCount++);

                            // Print account name at the end.
                            worksheet.Cells[accountsListRow, accountsCount + folderMaxDepth - 1].Value = permission.Account;
                            rightsCol = accountsCount + folderMaxDepth - 1;
                        }
                        else
                        {
                            rightsCol = userList[permission.Account] + folderMaxDepth;
                        }

                        worksheet.Cells[folderStartRow + item.Index, rightsCol].Value = permission.Rights;
                    }
                }

                CopyStyle(worksheet, folderStartRow, 1, folderStartRow + permissionsSubFolders.Count - 1, folderMaxDepth, folderBaseCellStyle);
                CopyStyle(worksheet, folderStartRow, folderMaxDepth + 1, folderStartRow + permissionsSubFolders.Count - 1, folderMaxDepth - 1 + accountsCount, rightsBaseCellStyle);
                CopyStyle(worksheet, 2, 1, 2, folderMaxDepth - 1 + accountsCount, accountBaseCellStyle);

                MergeFolderStructureHeader(worksheet, folderMaxDepth);

                worksheet.Cells.AutoFitColumns();
                progress?.Report(100);

                excel.SaveAs(new System.IO.FileInfo(fileNameFullPath));
            }
        }

        private static void MergeFolderStructureHeader(ExcelWorksheet worksheet, int folderMaxDepth)
        {
            worksheet.Cells[1, 1, 1, folderMaxDepth].Merge = true;
        }

        private static void CopyStyle(ExcelWorksheet worksheet, int destStartRow, int destStartCol, int destEndRow, int destEndCol, ExcelStyle baseStyle)
        {
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Border = baseStyle.Border;

            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.HorizontalAlignment = baseStyle.HorizontalAlignment;
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.VerticalAlignment = baseStyle.VerticalAlignment;
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Fill.PatternType = baseStyle.Fill.PatternType;
            if (!string.IsNullOrEmpty(baseStyle.Fill.BackgroundColor.Rgb))
            {
                worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Fill.BackgroundColor
                    .SetColor(ColorTranslator.FromHtml("#" + baseStyle.Fill.BackgroundColor.Rgb));
            }
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Border.Top.Style = baseStyle.Border.Top.Style;
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Border.Right.Style = baseStyle.Border.Right.Style;
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Border.Bottom.Style = baseStyle.Border.Bottom.Style;
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Border.Left.Style = baseStyle.Border.Left.Style;

            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Font.Bold = baseStyle.Font.Bold;
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Font.Italic = baseStyle.Font.Italic;
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Font.UnderLine = baseStyle.Font.UnderLine;
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Font.Family = baseStyle.Font.Family;
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Font.Name = baseStyle.Font.Name;
            worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Font.Size = baseStyle.Font.Size;

            if (!string.IsNullOrEmpty(baseStyle.Font.Color.Rgb))
            {
                worksheet.Cells[destStartRow, destStartCol, destEndRow, destEndCol].Style.Font.Color
                    .SetColor(ColorTranslator.FromHtml("#" + baseStyle.Font.Color.Rgb));
            }
        }

        public Tuple<TreeNodeCollection, List<FolderPermission>> ImportTemplate(string templatePath = null)
        {
            TemplatePath = templatePath ?? TemplatePath;

            var folderPermissionList = new List<FolderPermission>();

            var rootTreeNode = new TreeNode();

            using (var excel = new ExcelPackage(new System.IO.FileInfo(TemplatePath)))
            {
                var worksheet = excel.Workbook.Worksheets[Properties.Settings.Default.TemplateSheetName];
                FolderDepth = CountMergedCells(worksheet, worksheet.Cells["A1"].Worksheet.MergedCells[0]);
                var usernames = GetUserList().ToList();

                var fromRow = 3;
                const int startCol = 1;
                var isShiftedLevel = false;
                var currentNode = rootTreeNode;

                for (var colDepth = 0; colDepth < FolderDepth && colDepth >= 0;)
                {
                    var folderName = worksheet.Cells[fromRow, startCol + colDepth].GetValue<string>();

                    if (isShiftedLevel)
                    {
                        if (!string.IsNullOrWhiteSpace(folderName))
                        {
                            isShiftedLevel = false;
                            continue;
                        }
                        colDepth--;
                        currentNode = currentNode.Parent;
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(folderName))
                    {
                        currentNode = currentNode.Nodes[currentNode.Nodes.Count - 1];
                        isShiftedLevel = true;
                        colDepth++;
                        if (colDepth == FolderDepth)
                        {
                            colDepth--;
                            currentNode = currentNode.Parent;
                        }
                        continue;
                    }

                    var nodeKey = string.Empty + fromRow + string.Empty + (startCol + colDepth);
                    currentNode.Nodes.Add(nodeKey, folderName);

                    var userPermissionList = usernames
                        .Select((u, i) => new { Index = i, UserName = u })
                        .Select(item => new UserPermission
                        {
                            Username = item.UserName.Trim(),
                            Permission = worksheet.Cells[fromRow, startCol + FolderDepth + item.Index].Text.Trim()
                        })
                        .Where(p => !string.IsNullOrWhiteSpace(p.Permission))
                        .ToList();

                    fromRow++;

                    folderPermissionList.Add(new FolderPermission
                    {
                        UserPermission = userPermissionList,
                        NodeKey = nodeKey
                    });
                }

                return new Tuple<TreeNodeCollection, List<FolderPermission>>(rootTreeNode.Nodes, folderPermissionList);
            }
        }

        public List<Task> ApplyPermissionFromImportedTemplate(string path, string domain, TreeNodeCollection importedRootNodeChildren,
			List<FolderPermission> importedFolderPermissions)
        {
            var applyPermissionTasks = new List<Task>();
            
            foreach (TreeNode node in importedRootNodeChildren)
			{
				var currentFolderPermissions = importedFolderPermissions.First(p => p.NodeKey == node.Name);

				var subFolder = path + @"\" + node.Text;
                if (!Directory.Exists(subFolder))
                {
                    Logger.Error("Folder is not exists: {" + subFolder + "}");
                    continue;
                }
                
                applyPermissionTasks.Add(Task.Run(() => SetIndividualPermission(subFolder, domain, currentFolderPermissions, true)));
                applyPermissionTasks.AddRange(ApplyPermissionFromImportedTemplate(subFolder, domain, node.Nodes, importedFolderPermissions));
			}

            return applyPermissionTasks;
        }

        public void SetIndividualPermission(string folderPath, string domain, FolderPermission permissions, bool isEvictCurrentPermissions = false)
        {
            if (isEvictCurrentPermissions)
            {
                _permissionManipulator.EvictAllRightsCurrentFolderFromDomainUsers(folderPath, domain);
            }
            foreach (var permission in permissions.UserPermission)
            {
                _permissionManipulator.AssignPermission(folderPath, domain, permission);
            }
        }

        public async Task SetIndividualPermissionAsync(string folderPath, string domain, FolderPermission permissions, bool isEvictCurrentPermissions = false)
        {
            if (isEvictCurrentPermissions)
            {
                _permissionManipulator.EvictAllRightsCurrentFolderFromDomainUsers(folderPath, domain);
            }

            foreach (var permission in permissions.UserPermission)
            {
                await _permissionManipulator.AssignPermissionAsync(folderPath, domain, permission);
            }
        }

        #region Private Methods

        private IEnumerable<string> GetUserList()
        {
            using (var excel = new ExcelPackage(new System.IO.FileInfo(TemplatePath)))
            {
                var worksheet = excel.Workbook.Worksheets[Properties.Settings.Default.TemplateSheetName];
                const int row = 2;
                var startCol = FolderDepth + 1;

                while (true)
                {
                    var username = worksheet.Cells[row, startCol++].Text;
                    if (string.IsNullOrWhiteSpace(username)) break;

                    yield return username;
                }
            }
        }

        private int CountMergedCells(ExcelWorksheet worksheet, string cellsTemplate)
        {
            var groups = Regex.Match(cellsTemplate, @"(\w+\d)+:(\w+\d+)").Groups;
            var from = groups[1].Value;
            var to = groups[2].Value;

            return worksheet.Cells[to].End.Column - worksheet.Cells[from].End.Column + 1;
        }

        private static void FormatExcelHeader(ExcelWorksheet ws)
        {
            using (var range = ws.Cells[1, 1, 1, 4])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                range.Style.Font.Color.SetColor(Color.White);
            }
        }

        private static void FillFolderSize(ExcelWorksheet ws, string colToFillFolderInfo, int rowToFillFolderInfo, string path)
        {
            var fileSize_GB = DirectoryInfoExtractor.DirectorySize_Byte(path) / Math.Pow(1024, 3);

            ws.Cells[colToFillFolderInfo + 1].Value = "File size (GB)";
            ws.Cells[colToFillFolderInfo + rowToFillFolderInfo].Value = fileSize_GB;
            ws.Cells[colToFillFolderInfo + rowToFillFolderInfo].Style.Numberformat.Format = "#,##0.00";
        }

        public ExportInfo ToExportInfo(FileSystemAccessRule rule)
        {
            return new ExportInfo
            {
                Account = (rule.IsInherited ? "(I) " : string.Empty) + Regex.Replace(rule.IdentityReference.Value, @"^.*?[/\\]", string.Empty),
                Rights = (rule.FileSystemRights & Permissions.Instance.All["N"].Item1) == Permissions.Instance.All["N"].Item1 &&
                         rule.AccessControlType == AccessControlType.Deny ? "N" :
                    (rule.AccessControlType == AccessControlType.Allow ? string.Empty : "D") + 
                    (
                        (rule.FileSystemRights & Permissions.Instance.All["M"].Item1) == Permissions.Instance.All["M"].Item1 ? "M" : 
                        (rule.FileSystemRights & Permissions.Instance.All["R"].Item1) == Permissions.Instance.All["R"].Item1 ? "R" : "N/A"
                    )
            };
        }

        #endregion
    }
}
