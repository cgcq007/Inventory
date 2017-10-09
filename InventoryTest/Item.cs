using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace InventoryTest
{
    public class Item
    {
        public Item()
        {

        }
        // public int ItemId { get; set; }  
        public String ItemTitle { get; set; }

        [Key, MaxLength(255)]
        public String SN { get; set; }

        [MaxLength(255)]
        public string UPC { get; set; }

        [MaxLength(255)]
        public String OrderId { get; set; }

        [MaxLength(255)]
        public string OriginalTrackingNum { get; set; }
        public string Listed { get; set; }
        public DateTime DateOfRcv { get; set; }
        public string Condition { get; set; }

        [MaxLength(255)]
        public string ItemInOperator { get; set; }

        [MaxLength(255)]
        public string ServiceMan { get; set; }

        [MaxLength(300)]
        public String Note { get; set; }
        public bool? Pending { get; set; }
        [MaxLength(255)]
        public string ReturnCode { get; set; }
        [MaxLength(255)]
        public string Location { get; set; }
    }
}
