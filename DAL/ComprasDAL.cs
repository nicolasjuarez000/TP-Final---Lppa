using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ComprasDAL
    {

        private readonly DAO _db;

        public ComprasDAL(DAO db = null)
        {
            _db = db ?? new DAO();
        }

        public List<Compras> GetShoppingForUser(string username)
        {
            List<Compras> shoppingList = new List<Compras>();
            SqlParameter[] parameters = {
                   new SqlParameter("@USERNAME", username)
                };

            var tabla = _db.ReadStoredProcedure("SP_GET_SHOPPING_FOR_USER", parameters);

            foreach (DataRow registro in tabla.Rows)
            {
                var shopping = new Compras();
                shopping.Id = int.Parse(registro["ID"].ToString());
                shopping.FechaCompra = Convert.ToDateTime(registro["FECHACOMPRA"]);

                var _user = new User();
                _user.id = int.Parse(registro["ID"].ToString());
                _user.username = registro["USERNAME"].ToString();
                _user.email = registro["EMAIL"].ToString();
                _user.password = registro["PASSWORD"].ToString();
                switch (registro["USER_TYPE"].ToString())
                {
                    case "admin":
                        _user.userType = UserType.admin;
                        break;
                    case "webmaster":
                        _user.userType = UserType.webmaster;
                        break;
                    case "user":
                        _user.userType = UserType.user;
                        break;

                    default:
                        break;
                }

                var products = new Productos();
                products.Id = int.Parse(registro["ID"].ToString());
                products.Producto = registro["PRODUCTO"].ToString();

                shopping.User = _user;
                shopping.Productos = products;

                shoppingList.Add(shopping);
            }
            return shoppingList;
        }
    }
}
