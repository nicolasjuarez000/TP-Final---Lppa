using System;

namespace BE
{
    public class Purchase
    {
        public int id { get; set; }
        public int buyerId { get; set; }
        public int productId { get; set; }
        public DateTime date { get; set; }
        public int amount { get; set; }
    }
}
