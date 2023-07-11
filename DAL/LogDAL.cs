using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LogDAL
    {
        private readonly DAO _db;

        public LogDAL(DAO db = null)
        {
            _db = db ?? new DAO();
        }

        private void Create(BE.Log eventoBitacora)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@SEVERITY", eventoBitacora.Severity),
                    new SqlParameter("@DATE", eventoBitacora.Date),
                    new SqlParameter("@ASSOCIATED_INFO", eventoBitacora.AssociatedInfo)
                };
                _db.WriteStoredProcedure("SP_LOGS_CREATE", parameters);
            }
            catch (Exception ex)
            {
                throw new Excepciones.DatabaseUnknownErrorException();
            }
        }


        public void LogInformation(string infoAsociada)
        {
            Create(new BE.Log
            {
                Severity = "information",
                Date = DateTime.Now,
                AssociatedInfo = infoAsociada
            });
        }

        public void LogWarning(string infoAsociada)
        {
            Create(new BE.Log
            {
                Severity = "warning",
                Date = DateTime.Now,
                AssociatedInfo = infoAsociada
            });
        }

        public void LogError(string infoAsociada)
        {
            try
            {
                var bitacora = new BE.Log
                {
                    Severity = "error",
                    Date = DateTime.Now,
                    AssociatedInfo = infoAsociada
                };
                Create(bitacora);
            }
            catch (Exception ex)
            {
                throw new Excepciones.DatabaseUnknownErrorException();
            }
        }



        public List<BE.Log> GetAll()
        {
            List<BE.Log> eventosBitacora = new List<BE.Log>();
            var tabla = _db.ReadStoredProcedure("SP_LOGS_GET_ALL", null);

            foreach (DataRow registro in tabla.Rows)
            {
                var evento = new BE.Log
                {
                    ID = int.Parse(registro["ID"].ToString()),
                    Severity = registro["SEVERITY"].ToString(),
                    Date = DateTime.Parse(registro["DATE"].ToString()),
                    AssociatedInfo = registro["ASSOCIATED_INFO"].ToString()
                };
                eventosBitacora.Add(evento);
            }
            return eventosBitacora;
        }



    }
}
