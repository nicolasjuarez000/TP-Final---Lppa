using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;


namespace BLL
{
    public enum LoginResult { Success, Failure }
    public class UserBLL
    {

        public LoginResult Login(string username, string hashedPassword)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }

            return LoginResult.Failure;
        }
        
    }
    
    public User GetUser(string username)
    {
        
    }

}
