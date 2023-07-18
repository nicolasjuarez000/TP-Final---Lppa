using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;

namespace TP_Final___Lppa
{
    public partial class CorruptedDB : System.Web.UI.Page
    {
        private readonly BLL.BackupBLL _backupBLL;
        private BE.Backup _backup;
        public CorruptedDB()
        {
            _backupBLL = new BLL.BackupBLL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                if (Session["dbErrorType"] == null)
                {
                    Response.Redirect("Unauthorized.aspx");
                    return;
                }

            }
            else if (Session["Username"].ToString() == UserType.user.ToString() || Session["Username"].ToString() == UserType.admin.ToString())
            {
                if (Session["dbErrorType"] == null)
                {
                    Response.Redirect("Forbidden.aspx");
                }
            }
            btnRestore.Visible = false;

            var backups = _backupBLL.GetAll();
            GridView1.DataSource = backups;
            GridView1.DataBind();
            if (Session["dbErrorType"] != null)
            {
                if (Session["dbErrorType"].ToString() == "dvh")
                {
                    User user = (User)Session["User"];
                    string Message = "Error en la consistencia de la base de datos con el usuario " + user.username + ". La base de datos Debe ser restaurada.";
                    Response.Write("<script language='javascript'>alert('" + Message + "');</script>");
                }
                if (Session["dbErrorType"].ToString() == "dvv")
                {
                    string Message = "Error en la consistencia de la base de datos.";
                    Response.Write("<script language='javascript'>alert('" + Message + "');</script>");
                }
            }

           

            Session["dbErrorType"] = "";




        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            this._backup = new BE.Backup();
            this._backup.Fecha = Convert.ToDateTime(GridView1.SelectedRow.Cells[2].Text);
            this._backup.ID = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            this._backup.Username = GridView1.SelectedRow.Cells[3].Text;
            _backupBLL.Restore(_backup);
            Session["dbErrorType"] = null;
            Response.Redirect("BackupOK.aspx");
        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRestore.Visible = true;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.CssClass = "selected";
                }
                else
                {
                    row.CssClass = "";
                }
            }
        }

    }
}