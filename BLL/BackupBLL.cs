using System.Collections.Generic;

namespace BLL
{
    public class BackupBLL
    {
        private readonly DAL.BackupDAL _backupsData;
        private readonly LogBLL _log;

        public BackupBLL()
        {
            _backupsData = new DAL.BackupDAL();
            _log = new LogBLL();
        }

        public void Create(BE.Backup backup, BE.User user)
        {
            DAL.BackupDAL backupDAL = new DAL.BackupDAL();
            _backupsData.Create(backup);
            _log.LogInformation("El usuario " + user.username +" realizó un backup de la base de datos.");
        }

        public IList<BE.Backup> GetAll()
        {
            return _backupsData.GetAll();
        }

        public void Restore(BE.Backup backup)
        {
            _backupsData.Restore(backup);
            _log.LogInformation("Se realizó un restore de la base de datos");
        }
    }
}
