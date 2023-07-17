using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Excepciones
{
    public class UnauthorizedUpdateException : Exception
    {
        public UnauthorizedUpdateException() : base("integrity_check_failed_unauthorized_update_longversion")
        {
        }
    }
}
