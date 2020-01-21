using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupDBtoFolderCmd {
    class Program {
        
        static void Main(string[] args) {
            string sConn = string.Format(@"Data Source={0};Integrated Security=True", @"(localdb)\mssqllocaldb");
            SqlConnection connSql = new SqlConnection(sConn);
            connSql.Open();
            SqlCommand commSql = connSql.CreateCommand();
            string baseName = args[0];
            string backupPath = args[1];
            string backupName = string.Format("{0}\\{1}.bak", backupPath, baseName);
            string sqlQuery = String.Format("BACKUP DATABASE [{0}] TO  DISK = '{1}' WITH NOFORMAT, NOINIT,  NAME = N'{0}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", baseName, backupName);
            commSql.CommandText = sqlQuery;
            commSql.ExecuteNonQuery();
            connSql.Close();
        }
    }
}
