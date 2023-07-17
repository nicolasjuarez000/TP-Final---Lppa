using System;
using System.Web.UI;
using BE;
using BLL;

namespace TP_Final___Lppa
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Digitos_Verificadores.CheckDvh() != null)
            {
                User user = Digitos_Verificadores.CheckDvh();
                string Message = "Error en la consistencia de la base de datos. El usuario " + user.username + " Debe ser restaurado.";
                CreateErrorLog(Message);
                Response.Write("<script language='javascript'>alert('" + Message + "');</script>");
                //Response.End();
                Response.Redirect("CorruptedDB.aspx");
            }

            if (!Digitos_Verificadores.CheckDvTable("USER_DATA"))
            {
                string Message = "Error en la consistencia de la base de datos.";
                CreateErrorLog(Message);
                Response.Write("<script language='javascript'>alert('" + Message + "');</script>");
                //Response.Redirect("CorruptedDB.aspx");
                Response.End();
            }
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox2.Text; 
            string password = SecurityBLL.Hash(TextBox3.Text);

            UserBLL userBll = new UserBLL();
            User user = userBll.Login(username, password);
            if (user != null)
            {
                Session["Username"] = user;
                Session["_username"] = username;
                Response.Redirect("Landing.aspx");
            }
            else
            {
                lblloginerror.Text = "Nombre de usuario o contraseña incorrectos";
            }
        }



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

        /**
        private void GetAllLogs()
        {
            LogBLL bitacoraBLL = new LogBLL();
            bitacoraBLL.GetAll();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logs.aspx");
        }
        **/
    }
}