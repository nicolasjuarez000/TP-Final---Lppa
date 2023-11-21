using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cart
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public decimal totalPrice { get; set; }
        public int quantity { get; set; }
    }
}
