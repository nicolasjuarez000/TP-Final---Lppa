using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Compras
    {
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; }
        public User User { get; set; }
        public Productos Productos { get; set; }
    }
}
