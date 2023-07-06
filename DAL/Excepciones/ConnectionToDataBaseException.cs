using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Excepciones
{
    public class ConnectionToDataBaseException : Exception
    {
        public ConnectionToDataBaseException() : base("Error conecting to DB")
        {
        }
    }
}
