using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            var backups = _backupBLL.GetAll();
            GridView1.DataSource = backups;
            GridView1.DataBind();
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            this._backup = new BE.Backup();
            this._backup.Fecha = Convert.ToDateTime(GridView1.SelectedRow.Cells[2].Text);
            this._backup.ID = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            this._backup.Username = GridView1.SelectedRow.Cells[3].Text;
            _backupBLL.Restore(_backup);
        }
    }
}