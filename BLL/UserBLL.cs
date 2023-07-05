using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public enum LoginResult { Success, Failure }
    public class UserBLL
    {

        public LoginResult Login(string username, string hashedPassword)
        {
            return LoginResult.Failure;
        }
    }
}
