using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BuyerBLL
    {
        private readonly DAL.BuyerDAL _buyerDAL;
        
        public BuyerBLL()
        {
            _buyerDAL = new DAL.BuyerDAL();
        }

        public List<BE.Buyer> getAllBuyers()
        {
            return _buyerDAL.GetAll();
        }
    }
}
