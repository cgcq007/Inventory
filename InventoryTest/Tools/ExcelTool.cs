using System;
using System.IO;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace InventoryTest
{
    class ExcelTool
    {
        private DataTable dt;
        private string path;
        public ExcelTool(DataTable dt, string path)
        {
            this.dt = dt;
            this.path = path;
        }
   
        public string writeToExcel()
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
                            ICellStyle cs = workbook.CreateCellStyle();
                            cs.WrapText = true;
                            dataRow.GetCell(j).CellStyle = cs;
                            //dataRow.HeightInPoints = 2 * sheet.DefaultRowHeight / 20;
                        }
                    }
                }
                using (FileStream file = new FileStream(path+"\\BakLog.xls", FileMode.Create, FileAccess.Write))
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
