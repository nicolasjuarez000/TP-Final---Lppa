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
    }
}