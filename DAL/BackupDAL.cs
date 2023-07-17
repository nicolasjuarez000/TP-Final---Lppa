using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BackupDAL
    {
        private readonly DAO _db;
        private readonly LogDAL _log;
        private readonly string backupsPath = @"D:\TiendaLPPA backups\";

        public BackupDAL()
        {
            _db = new DAO();
            _log = new LogDAL();
        }


        public void Create(BE.Backup backup)
        {
            try
            {
                var backups = GetAll();
                backup.ID = backups.Count > 0 ? backups.First().ID + 1 : 1; //no es identidad. se usa el first() en lugar de last() porque se trae los registros ordenados por fecha en orden descendiente
                SqlParameter[] parameters = {
                    new SqlParameter("@idBackup", backup.ID),
                    new SqlParameter("@username", backup.Username),
                    new SqlParameter("@Fecha", backup.Fecha),
                    new SqlParameter("@SystemPath", backupsPath),
                };
                _db.WriteStoredProcedure("SP_BACKUP_CREATE", parameters);
            }
            catch (SqlException ex)
            {
                _log.LogError(ex.StackTrace);
                throw new Excepciones.DatabaseUnknownErrorException();
            }
        }

        public IList<BE.Backup> GetAll()
        {
            try
            {
                var backups = new List<BE.Backup>();
                var tabla = _db.ReadStoredProcedure("SP_BACKUP_GET_ALL", null);

                foreach (DataRow registro in tabla.Rows)
                {
                    var backup = new BE.Backup()
                    {
                        ID = int.Parse(registro["id_Backup"].ToString()),
                        Username = registro["username"].ToString(),
                        Fecha = DateTime.Parse(registro["Fecha"].ToString())
                    };
                    backups.Add(backup);
                }
                return backups;
            }
            catch (SqlException ex)
            {
                _log.LogError(ex.StackTrace);
                throw new Excepciones.DatabaseUnknownErrorException();
            }
        }

        public void Restore(BE.Backup backup)
        {
            try
            {
                string query = @"
                DECLARE @TablaAntesDelRestore TABLE(idBackup INT,Fecha datetime, username varchar(50), SystemPath nvarchar(260));
                INSERT INTO @TablaAntesDelRestore(idBackup, Fecha, username, SystemPath)
                SELECT id_Backup, Fecha, username, System_Path FROM Backups;
                declare @backup_path nvarchar(260) = (select top (1) System_Path from Backups where id_Backup = @idBackup)
                USE [master];
	            ALTER DATABASE TiendaLPPA SET SINGLE_USER WITH ROLLBACK IMMEDIATE; --si hay conexiones abiertas no se puede hacer el restore
	            RESTORE DATABASE TiendaLPPA FROM DISK =  @backup_path  WITH REPLACE;
	            ALTER DATABASE TiendaLPPA SET MULTI_USER; -- restaurar acceso de multiples usuarios
	            USE [TiendaLPPA];
                delete from Backups
	            insert into Backups (id_Backup, Fecha, username,System_Path)
	            SELECT idBackup, Fecha, username, SystemPath FROM @TablaAntesDelRestore";

                using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TiendaLPPA;Integrated Security=True"))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idBackup", backup.ID);
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                _log.LogError(ex.StackTrace);
                throw new Excepciones.DatabaseUnknownErrorException();
            }
        }
    }
}
