using System;
using System.ComponentModel.DataAnnotations;


namespace InventoryTest
{
    class ItemInbound
    {
        public ItemInbound()
        {

        }
        [Key]
        public int ItemInboundId { get; set; }

        [MaxLength(255)]
        public String ItemTitle { get; set; }

        public String UPC { get; set; }

        [MaxLength(255)]
        public String TrackingNum { get; set; }

        public String Manipulator { get; set; }

        public String ShipperId { get; set; }

        public int Qty { get; set; }

        public DateTime Date { get; set; }

        public Boolean isDelete { get; set; }


    }

}
