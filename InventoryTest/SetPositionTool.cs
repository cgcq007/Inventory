using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryTest
{
    class SetPositionTool
    {
        public void returnCurrentRow(int currentRowIndex, DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Index == currentRowIndex)
                {
                    dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    row.Selected = true;
                }
            }
        }
        public void returnCurrentRow(string currentRowSN, DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["SN"].Value.ToString() == currentRowSN)
                {
                    dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    row.Selected = true;
                }
            }
        }
        public void returnCurrentOutboundRow(string currentRowId, DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["ItemOutboundId"].Value.ToString() == currentRowId)
                {
                    dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    row.Selected = true;
                }
            }
        }
        public void returnCurrentInboundRow(string currentRowId, DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["ItemInboundId"].Value.ToString() == currentRowId)
                {
                    dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    row.Selected = true;
                }
            }
        }
    }
}
