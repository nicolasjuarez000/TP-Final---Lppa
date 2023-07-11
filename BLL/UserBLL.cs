using System;
using BE;


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
   

}
