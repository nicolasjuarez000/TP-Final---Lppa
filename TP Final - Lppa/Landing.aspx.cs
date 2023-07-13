﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

namespace TP_Final___Lppa
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["Username"];
            lblusername.Text = user.username;

            if (user.userType  == UserType.user)
            {
                btnlogs.Visible = false;
            }
        }

        protected void btnlogs_Click(object sender, EventArgs e)
        {
            LogBLL logbll = new LogBLL();
            User User = (User)Session["Username"];
            logbll.LogInformation("El usuario " + User.username + " ingresó en la bitácora.");
            Response.Redirect("Logs.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User User = (User)Session["Username"];
            LogBLL logbll = new LogBLL();
            logbll.LogInformation("El usuario " + User.username + " se deslogueó del sistema.");
            Session["Username"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}