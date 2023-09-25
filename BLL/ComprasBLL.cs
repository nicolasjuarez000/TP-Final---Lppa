using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ComprasBLL
    {
        private ComprasDAL _comprasDAL;
        public ComprasBLL()
        {
            _comprasDAL = new ComprasDAL();
        }

        public List<Compras> GetshoppingForUser(string userName)
        {
            return _comprasDAL.GetShoppingForUser(userName);
        }
    }
}
