using System;
using System.IO;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Windows.Forms;

namespace InventoryTest
{
    class ExcelTool
    {
        private string path;
        public ExcelTool()
        {
            
        }

        public bool initSavePath() {
            SaveFileDialog sfd = new SaveFileDialog();
            //path.Description = "Please Choose a Path:";
           

            //设置文件类型 
            sfd.Filter = "Excel Document(*.xls)|*.xls";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //设置默认的文件名
            sfd.FileName = "BackLog";
            sfd.DefaultExt = ".xls";// in wpf is  sfd.FileName = "YourFileName";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //file = path.SafeFileName;
                path = sfd.FileName.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        public string writeToExcel(DataTable dt)
        {  
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet();
                IRow dataRow = sheet.CreateRow(0);
                sheet.DefaultColumnWidth = 20;
                sheet.DefaultRowHeight = 20 * 20;
                
                foreach (DataColumn column in dt.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                }
                ICellStyle cs = workbook.CreateCellStyle();
                cs.WrapText = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //first line uses Create
                    dataRow = sheet.CreateRow(i+1);


                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //second row uses get
                        dataRow.CreateCell(j).SetCellValue(Convert.ToString(dt.Rows[i][j]));
                        //cover /n
                        if (dt.Rows[i][j].ToString().Contains("\n"))
                        {

                            dataRow.GetCell(j).CellStyle = cs;
                            //dataRow.HeightInPoints = 2 * sheet.DefaultRowHeight / 20;
                        }
                    }
                }
                using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(file);
                    file.Close();
                    file.Dispose();
                }
                return "Successfully saved!";
                
            }
            catch (Exception ex)
            {
               return ex.Message.ToString();
            }
        }

    }
}
