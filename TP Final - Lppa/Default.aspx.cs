using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

namespace TP_Final___Lppa
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox2.Text; 
            string password = SecurityBLL.Hash(TextBox3.Text);

            UserBLL userBll = new UserBLL();
            userBll.Login(username, password);
        }

        /*protected void Button1_Click(object sender, EventArgs e)  Comentado para que no tire error
        {
            string username = TextBox2.Text;
            string password = SecurityBLL.Hash(TextBox3.Text);

            UserBLL userBll = new UserBLL();
            if (userBll.Login(username, password) == LoginResult.Success)
            {
                Response.Write("");
            }
            else
            {
                //Printear nombre de usuario o contraseña incorrecta
            }
        }*/

        private void CreateInformationLog(string AssociatedInfo)  //La idea del AssociatedInfo es por ejemplo: si es excepcion
                                                                  //poner el mensaje, o si es un login poner el username del usuario logeado, etc
        {
            LogBLL bitacoraBLL = new LogBLL();
            bitacoraBLL.LogInformation(AssociatedInfo);
        }

        private void CreateWarningLog(string AssociatedInfo)
        {
            LogBLL bitacoraBLL = new LogBLL();
            bitacoraBLL.LogWarning(AssociatedInfo);
        }

        private void CreateErrorLog(string AssociatedInfo)
        {
            LogBLL bitacoraBLL = new LogBLL();
            bitacoraBLL.LogError(AssociatedInfo);
        }

        private void GetAllLogs()
        {
            LogBLL bitacoraBLL = new LogBLL();
            bitacoraBLL.GetAll();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logs.aspx");
        }
    }
}