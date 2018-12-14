using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryTest
{
    class ItemOutbound
    {
        public ItemOutbound()
        {

        }
        [Key]
        public int ItemOutboundId { get; set; }

        [MaxLength(255)]
        public String ItemTitle { get; set; }
        
        public String SN { get; set; }

        [MaxLength(255), Index("IX_IOTRACKNUM", IsClustered = false)]
        public String TrackingNum { get; set; }

        public String Manipulator { get; set; }
        
        public int Qty { get; set; }

        public DateTime Date { get; set; }

        public Boolean isDelete { get; set; }
        
        
    }

}
