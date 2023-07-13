using System;
using BE;
using DAL;

namespace BLL
{
    //public enum LoginResult { Success, Failure }
    public class UserBLL
    {

        public User Login(string username, string hashedPassword)
        {
            try
            {
                UserDAL userdal = new UserDAL();
                User user = userdal.GetUserbyUsername(username);

                if (user.password == hashedPassword)
                {
                    LogBLL logbll = new LogBLL();
                    logbll.LogInformation("El usuario " + username + " se logueo exitosamente");
                    return user;
                }
                else
                {
                    LogBLL logbll = new LogBLL();
                    logbll.LogWarning("Se ingresó una contraseña incorrecta para " + username );
                }

            }
            catch (Exception e)
            {
                LogBLL logbll = new LogBLL();
                logbll.LogError(e.Message + " Al intentar loguear a " + username);
                return null;
            }

            return null;
        }

        
    }
   

}
