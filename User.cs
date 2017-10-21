using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventoryTest
{
    public class User
    {
        public User()
        {

        }

        [Key]
        public string UserName { get; set; }
        public String UserPwd { get; set; }
        public string UserType { get; set; }
    }
}
