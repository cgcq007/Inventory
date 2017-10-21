using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryTest
{
    class DLTool
    {
        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行
        DataTable dtInfo = new DataTable();
        DataGridView dataGridView;


        public DLTool(DataTable dtInfo, DataGridView dataGridView)
        {
            this.dtInfo = dtInfo;
            this.dataGridView = dataGridView;
        }

        private void InitDataSet()
        {
            pageSize = 40;      //设置页面行数
            nMax = dtInfo.Rows.Count;

            pageCount = (nMax / pageSize);    //计算出总页数

            if ((nMax % pageSize) > 0) pageCount++;

            pageCurrent = 1;    //当前页数从1开始
            nCurrent = 0;       //当前记录数从0开始

            LoadData();
        }
        private void LoadData()
        {
            int nStartPos = 0;   //当前页面开始记录行
            int nEndPos = 0;     //当前页面结束记录行

            DataTable dtTemp = dtInfo.Clone();   //克隆DataTable结构框架

            if (pageCurrent == pageCount)
                nEndPos = nMax;
            else
                nEndPos = pageSize * pageCurrent;

            nStartPos = nCurrent;

            //toolStripLabel1.Text = pageCount.ToString();
            //toolStripTextBox1.Text = Convert.ToString(pageCurrent);
            //itemCount.Text = Convert.ToString(dtInfo.Rows.Count);

            //从元数据源复制记录行
            if (dtInfo.Rows.Count == 0)
            {
                dataGridView.DataSource = dtInfo;
                return;
            }
            for (int i = nStartPos; i < nEndPos; i++)
            {
                dtTemp.ImportRow(dtInfo.Rows[i]);
                nCurrent++;
            }
            BindingSource bdsInfo = new BindingSource();
            bdsInfo.DataSource = dtTemp;
            dataGridView.DataSource = bdsInfo;
        }
    }
}
