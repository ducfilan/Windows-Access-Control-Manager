using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SetACLs.Model;

namespace SetACLs
{
    class ToolBusiness
    {
        public string TemplatePath { get; set; }
        private FacHelper _facHelper;

        public ToolBusiness()
        {
	        _facHelper = new FacHelper();
        }

        public int FolderDepth { get; set; }

        internal async void ExportPermission(string permissionToCheckPath, string fileNameFullPath, string domain)
        {
            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Permission");

                var permissions = await GetPermissions(permissionToCheckPath, domain);

                ws.Cells["A1"].LoadFromCollection(permissions, true);
                ws.Cells.AutoFitColumns(0);

                using (var range = ws.Cells[1, 1, 1, 4])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                    range.Style.Font.Color.SetColor(Color.White);
                }

                excel.SaveAs(new FileInfo(fileNameFullPath));
            }

            Process.Start(fileNameFullPath);
        }

        public async Task<IEnumerable<PermissionsModel>> GetPermissions(string permissionToCheckPath, string domain)
        {
	        return (await new GetFolderPermission(permissionToCheckPath).GetPermissionAsync())
		        .Where(p => string.IsNullOrEmpty(domain) || p.IdentityReference.StartsWith(domain));
        }

        public void SetPermission(string path)
        {
	        MessageBox.Show(path);
			_facHelper.AddAllowRightFull(path, @"FSOFT.FPT.VN\TuyenNP");
        }

        public IEnumerable<string> GetUserList()
        {
            using (var excel = new ExcelPackage(new FileInfo(TemplatePath)))
            {
                var worksheet = excel.Workbook.Worksheets["Template"];
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

        public Tuple<TreeNode, List<FolderPermission>> ImportTemplate(string templatePath = null)
        {
            TemplatePath = templatePath ?? TemplatePath;

            var folderPermissionList = new List<FolderPermission>();

            var rootTreeNode = new TreeNode();

            using (var excel = new ExcelPackage(new FileInfo(TemplatePath)))
            {
                var worksheet = excel.Workbook.Worksheets["Template"];
                FolderDepth = CountMergedCells(worksheet.Cells["A1"].Worksheet.MergedCells[0]);
                var usernames = GetUserList().ToList();

                var fromRow = 3;
                const int startCol = 1;
                var isShiftedLevel = false;
                var currentNodeChildren = rootTreeNode.Nodes;

                TreeNodeCollection prevNode = null;

                for (var colDepth = 0; colDepth < FolderDepth;)
                {
                    var folderName = worksheet.Cells[fromRow, startCol + colDepth].GetValue<string>();

                    if (string.IsNullOrWhiteSpace(folderName))
                    {
                        if (isShiftedLevel)
                        {
                            colDepth -= 2;
                            isShiftedLevel = false;
                            currentNodeChildren = prevNode[0].Parent.Parent.Nodes;
                            fromRow++;
                            continue;
                        }

                        colDepth++;
                        prevNode = currentNodeChildren;
                        currentNodeChildren = currentNodeChildren[currentNodeChildren.Count - 1].Nodes;
                        isShiftedLevel = true;
                        continue;
                    }

                    isShiftedLevel = false;

                    var nodeKey = string.Empty + fromRow + string.Empty + (startCol + colDepth);
                    currentNodeChildren.Add(nodeKey, folderName);

                    var userPermissionList = usernames
                        .Select((u, i) => new {Index = i, UserName = u})
                        .Select(item => new UserPermission
                        {
                            Username = item.UserName,
                            Permission = worksheet.Cells[fromRow, startCol + FolderDepth + item.Index].Text
                        }).ToList();

                    fromRow++;

                    folderPermissionList.Add(new FolderPermission
                    {
                        UserPermission = userPermissionList,
                        NodeKey = nodeKey
                    });
                }

                return new Tuple<TreeNode, List<FolderPermission>>(rootTreeNode, folderPermissionList);
            }
        }

        private int CountMergedCells(string cellsTemplate)
        {
            var groups = Regex.Match(cellsTemplate, @"(\w+)\d+:(\w+)\d+").Groups;
            var from = groups[1].Value[0];
            var to = groups[2].Value[0];

            return to - from + 1;
        }
    }
}
