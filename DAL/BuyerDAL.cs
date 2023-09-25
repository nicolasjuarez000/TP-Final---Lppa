using BE;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class BuyerDAL
    {
        private readonly DAO _db;

        public BuyerDAL(DAO db = null)
        {
            _db = db ?? new DAO();
        }

        public List<Buyer> GetAll()
        {
            List<Buyer> buyersList = new List<Buyer>();
            var tabla = _db.ReadStoredProcedure("SP_BUYERS_GET_ALL", null);

            foreach (DataRow registro in tabla.Rows)
            {
                var buyer = new Buyer();
                buyer.id = int.Parse(registro["ID"].ToString());
                buyer.name = registro["NAME"].ToString();
                buyer.surname = registro["SURNAME"].ToString();
                buyersList.Add(buyer);
            }
            return buyersList;
        }
    }
}
