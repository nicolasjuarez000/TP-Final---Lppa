using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CartDAL
    {
        private readonly DAO _db;

        public CartDAL(DAO db = null)
        {
            _db = db ?? new DAO();
        }

        public void addItem(BE.Cart cart)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@productId", cart.productID),
                    new SqlParameter("@productName", cart.productName),
                    new SqlParameter("@totalPrice", cart.totalPrice),
                    new SqlParameter("@quantity", cart.quantity)
                };
                _db.WriteStoredProcedure("SP_CART_ADD_ITEMS", parameters);
            } 
            catch(Exception ex)
            {
                throw new Excepciones.DatabaseUnknownErrorException();
            }
        }

        /*public BE.Cart getCart()
        {
            List<BE.Cart> productsList = new List<BE.Cart>();
            var tabla = _db.ReadStoredProcedure("SP_CART_GET", null);

            foreach (DataRow registro in tabla.Rows)
            {
                var evento = new BE.Cart
                {
                    productID = int.Parse(registro["productId"].ToString()),
                    productName = registro["productName"].ToString(),
                    totalPrice = decimal.Parse(registro["totalPrice"].ToString()),
                    quantity = int.Parse(registro["quantity"].ToString())
                };
                productsList.Add(evento);
            }
            return productsList;
        }*/
    }
}
