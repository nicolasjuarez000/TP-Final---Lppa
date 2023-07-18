using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;

namespace TP_Final___Lppa
{
    public partial class Logs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Unauthorized.aspx");
                return;
            }
            else if (Session["Username"].ToString() == UserType.user.ToString())
            {
                Response.Redirect("Forbidden.aspx");
            }

            BLL.LogBLL logBLL = new BLL.LogBLL();
            var logs = logBLL.GetAll();
            GridView1.DataSource = logs;
            GridView1.DataBind();
           
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}