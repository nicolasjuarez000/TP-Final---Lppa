using System.Collections.Generic;

namespace BLL
{
    public class LogBLL
    {
        public void LogInformation(string infoAsociada)
        {
            DAL.LogDAL bitacoraDAL = new DAL.LogDAL();
            bitacoraDAL.LogInformation(infoAsociada);
        }

        public void LogWarning(string infoAsociada)
        {
            DAL.LogDAL bitacoraDAL = new DAL.LogDAL();
            bitacoraDAL.LogWarning(infoAsociada);
        }

        public void LogError(string infoAsociada)
        {
            DAL.LogDAL bitacoraDAL = new DAL.LogDAL();
            bitacoraDAL.LogError(infoAsociada);
        }


        public List<BE.Log> GetAll()
        {
            DAL.LogDAL bitacoraDAL = new DAL.LogDAL();
            return bitacoraDAL.GetAll();
        }

    }
}
