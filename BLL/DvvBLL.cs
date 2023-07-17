using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DvvBLL
    {
        public int CalcularDV(BE.User)
        {
            DAL.DvvDAL dvvDAL = new DAL.DvvDAL();
            dvvDAL.CalcularDigitoVerificador(BE.User user);
        }
    }
}
