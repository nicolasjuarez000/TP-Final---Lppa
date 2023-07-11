using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final___Lppa
{
    public partial class Logs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.LogBLL logBLL = new BLL.LogBLL();
            var logs = logBLL.GetAll();
            GridView1.DataSource = logs;
            GridView1.DataBind();
        }
    }
}