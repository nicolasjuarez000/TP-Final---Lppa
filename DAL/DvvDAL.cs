using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DvvDAL
    {
        private readonly DAO _db;
        private readonly LogDAL _logDAL;

        public DvvDAL(DAO db = null, LogDAL logDAL = null)
        {
            _db = db ?? new DAO();
            _logDAL = logDAL ?? new LogDAL();
        }

        public BE.DVV Get(string nombreTabla)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@Tabla", nombreTabla) };
                var tabla = _db.ReadStoredProcedure("DVV_GET", parameters);
                BE.DVV dvv = new BE.DVV(nombreTabla, (byte[])tabla.Rows[0]?["DVV"]);
                return dvv;
            }
            catch (SqlException ex)
            {
                _logDAL.LogError(ex.StackTrace);
                throw new Excepciones.DatabaseUnknownErrorException();
            }
        }

        public void Update(BE.DVV dvv)
        {
            try
            {
                SqlParameter[] parameters = {
                new SqlParameter("@Tabla", dvv.Tabla),
                new SqlParameter("@DVV", dvv.DV)
            };

                _db.WriteStoredProcedure("DVV_UPDATE", parameters);
            }
            catch (SqlException ex)
            {
                _logDAL.LogError(ex.StackTrace);
                throw new Excepciones.DatabaseUnknownErrorException();
            }
        }

        /*public VOID RecalcularDigitos()
        {
            try
            {
                UserDAL _userDAL = new UserDAL();
                _productoDAL.RecalcularDigitos();
            }
            catch (SqlException ex)
            {
                _logDAL.LogError(ex.StackTrace);
                throw new Excepciones.DatabaseUnknownErrorException();
            }
        }*/

        public int CalcularDigitoVerificador(BE.User user)
        {
            string data = user.username + user.email + user.password + user.userType.ToString();
            int suma = 0;

            for (int i = 0; i < data.Length; i++)
            {
                int digito = int.Parse(data[i].ToString());

                if (i % 2 == 0)
                {
                    digito *= 2;

                    if (digito > 9)
                        digito = digito % 10 + digito / 10;
                }

                suma += digito;
            }

            return 10 - (suma % 10);
        }
    }
}
