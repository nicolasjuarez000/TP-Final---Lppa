using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final___Lppa
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int serverPort = Request.Url.Port;
            string backupuri = Request.Url.AbsoluteUri;
            string uri = backupuri.Substring(0, backupuri.Length - 8); //me quedo con la uri hasta la /
            string defaulturi = "\"" + uri + "Default" + "\"";

            Response.Write(@"
        <script>
            setTimeout(function() {
                window.location.href = " + defaulturi + @";  // Replace with your desired URL
            }, 5000);  // Delay in milliseconds (e.g., 5000 milliseconds = 5 seconds)
        </script>
    ");


        }
    }
}