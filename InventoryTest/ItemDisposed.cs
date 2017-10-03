using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventoryTest
{
    class ItemDisposed
    {
        public ItemDisposed()
        {

        }
        public String ItemTitle { get; set; }
        [Key,MaxLength(255)]
        public String SN { get; set; }

        [MaxLength(255)]
        public string UPC { get; set; }

        [MaxLength(255)]
        public String OrderId { get; set; }
        public string Listed { get; set; }
        public DateTime DateOfRcv { get; set; }
        public DateTime DateOfOut { get; set; }
        [MaxLength(255)]
        public string OriginalTrackingNum { get; set; }
        [MaxLength(255)]
        public string OutTrackingNumber { get; set; }
        public string Condition { get; set; }

        [MaxLength(255)]
        public string ItemInOperator { get; set; }

        [MaxLength(255)]
        public string ServiceMan { get; set; }

        [MaxLength(255)]
        public string ItemOutOperator { get; set; }

        [MaxLength(255)]
        public string LPN { get; set; }
        [MaxLength(200)]
        public String Note { get; set; }
        [MaxLength(255)]
        public string ReturnCode { get; set; }
        [MaxLength(255)]
        public string Location { get; set; }
    }

}
