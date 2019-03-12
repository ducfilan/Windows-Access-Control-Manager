using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SetACLs.Const;
using SetACLs.Model;

namespace SetACLs.Business
{
	public class ToolBusiness
	{
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
				var permissionsSubFolders = _permissionManipulator.GetPermissionsSubFolders(permissionToCheckRootPath, domain)
                    .Select((p, i) => new {Index = i + 1, Permissions = p})
                    .ToList();

                foreach (var item in permissionsSubFolders)
                {
                    progress?.Report(50 + item.Index * 50 / permissionsSubFolders.Count);

                    var outputServerPath = item.Permissions.Key.Replace(permissionToCheckRootPath, @"\\" + serverIpAddress);

                    var rowToFillFolderInfo = item.Index + addedRowsCountToPrint + (isHeaderPrinted ? 0 : 1);

                    ws.Cells["A" + rowToFillFolderInfo].Value = outputServerPath;

                    FillFolderSize(ws, "B",rowToFillFolderInfo, item.Permissions.Key);

                    ws.Cells["C" + (item.Index + addedRowsCountToPrint)].LoadFromCollection(item.Permissions.Value.Select(ToExportInfo), !isHeaderPrinted);
                    addedRowsCountToPrint += item.Permissions.Value.Count() + (isHeaderPrinted ? 0 : 1);

                    isHeaderPrinted = true;
                }
				ws.Cells.AutoFitColumns(0);

				FormatExcelHeader(ws);

				excel.SaveAs(new FileInfo(fileNameFullPath));
			}
        }

        public Tuple<TreeNodeCollection, List<FolderPermission>> ImportTemplate(string templatePath = null)
        {
            TemplatePath = templatePath ?? TemplatePath;

            var folderPermissionList = new List<FolderPermission>();

            var rootTreeNode = new TreeNode();

            using (var excel = new ExcelPackage(new FileInfo(TemplatePath)))
            {
                var worksheet = excel.Workbook.Worksheets[Properties.Settings.Default.TemplateSheetName];
                FolderDepth = CountMergedCells(worksheet.Cells["A1"].Worksheet.MergedCells[0]);
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

        public void ApplyPermissionFromImportedTemplate(string path, string domain, TreeNodeCollection importedRootNodeChildren,
			List<FolderPermission> importedFolderPermissions)
        {
            _permissionManipulator.EvictAllRightsFromDomainUsers(path, domain);

            foreach (TreeNode node in importedRootNodeChildren)
			{
				var currentFolderPermissions = importedFolderPermissions.First(p => p.NodeKey == node.Name);

				var subFolder = path + @"\" + node.Text;
				SetIndividualPermission(subFolder, domain, currentFolderPermissions);
				ApplyPermissionFromImportedTemplate(subFolder, domain, node.Nodes, importedFolderPermissions);
			}
		}

        #region Private Methods

        private IEnumerable<string> GetUserList()
        {
            using (var excel = new ExcelPackage(new FileInfo(TemplatePath)))
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

        private int CountMergedCells(string cellsTemplate)
        {
            var groups = Regex.Match(cellsTemplate, @"(\w+)\d+:(\w+)\d+").Groups;
            var from = groups[1].Value[0];
            var to = groups[2].Value[0];

            return to - from + 1;
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
                Account = Regex.Replace(rule.IdentityReference.Value, @"^.*?[/\\]", string.Empty),
                Rights = (rule.FileSystemRights & Permissions.Instance.All["N"].Item1) == Permissions.Instance.All["N"].Item1 &&
                         rule.AccessControlType == AccessControlType.Deny ? "N" :
                    (rule.AccessControlType == AccessControlType.Allow ? string.Empty : "D") + 
                    (
                        (rule.FileSystemRights & Permissions.Instance.All["M"].Item1) == Permissions.Instance.All["M"].Item1 ? "M" : 
                        (rule.FileSystemRights & Permissions.Instance.All["R"].Item1) == Permissions.Instance.All["R"].Item1 ? "R" : "N/A"
                    )
            };
        }

        private void SetIndividualPermission(string folderPath, string domain, FolderPermission permissions)
        {
            foreach (var permission in permissions.UserPermission)
            {
                _permissionManipulator.AssignPermission(folderPath, domain, permission);
            }
        }

        #endregion
    }
}
