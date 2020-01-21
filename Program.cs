using DophinMSSQLConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupDBtoFolderCmd {
    class Program {
        
        static void Main(string[] args) {
            //StreamReader sr = new StreamReader(@"C:\MSSQLSettings.ini");
            //string st = sr.ReadToEnd();
            //sr.Close();
            //MsSqlConnector.GetSettingsFromTxt(st);
            MsSqlConnector.MsServerName = @"(localdb)\mssqllocaldb";
            MsSqlConnector.MsIntegratedSecurity = true; 
            MsSqlConnector.Open();
            string baseName = args[0];
            string backupPath = args[1];
            string backupName = string.Format("{0}\\[{1}].bak", backupPath, baseName);
            string sqlQuery = String.Format("BACKUP DATABASE [{0}] TO  DISK = '{1}' WITH NOFORMAT, NOINIT,  NAME = N'{0}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", baseName, backupName);
            MsSqlConnector.MakeNonQuery(sqlQuery);
            MsSqlConnector.Close();
        }
    }
}
