using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDAL
    {

        private readonly DAO _db;

        public UserDAL(DAO db = null)
        {
            _db = db ?? new DAO();
        }

        public User GetUserbyUsername(string username)
        {
            User user = new User();
            SqlParameter[] parameters = {
                   new SqlParameter("@USERNAME", username)
                };

            var tabla = _db.ReadStoredProcedure("SP_GET_USER_INFO_BY_USERNAME", parameters);

            foreach (DataRow registro in tabla.Rows)
            {

                user.id = int.Parse(registro["ID"].ToString());
                user.username = registro["USERNAME"].ToString();
                user.email = registro["EMAIL"].ToString();
                user.password = registro["PASSWORD"].ToString();
                switch (registro["USER_TYPE"].ToString())
                {
                    case "admin":
                        user.userType = UserType.admin;
                        break;
                    case "webmaster":
                        user.userType = UserType.webmaster;
                        break;
                    case "user":
                        user.userType = UserType.user;
                        break;

                    default:
                        break;
                }


            }
            return user;
        }

        public List<User> GetAll()
        {
            List<User> usersList = new List<User>();
            var tabla = _db.ReadStoredProcedure("SP_GET_USER_ALL", null);

            foreach (DataRow registro in tabla.Rows)
            {
                var user = new User();
                user.id = int.Parse(registro["ID"].ToString());
                user.username = registro["USERNAME"].ToString();
                user.email = registro["EMAIL"].ToString();
                user.password = registro["PASSWORD"].ToString();
                user.dvh = (byte[])registro["DV"];
                switch (registro["USER_TYPE"].ToString())
                {
                    case "admin":
                        user.userType = UserType.admin;
                        break;
                    case "webmaster":
                        user.userType = UserType.webmaster;
                        break;
                    case "user":
                        user.userType = UserType.user;
                        break;

                    default:
                        break;
                }
                usersList.Add(user);
            }
            return usersList;
        }
    }
}
