using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AclTrek
{
    public class AcLogSettings
    {
        public AppGeneralSettings AppGeneral { get; set; }
        public IList<Accessmdb> AccessMdbs { get; set; }
        public IList<Sqlserver> SqlServers { get; set; }
        public WindowsUserSettings WindowsUser { get; set; }
    }

    public class AppGeneralSettings
    {
        public string LogFilePath { get; set; }
    }

    public class WindowsUserSettings
    {
        public string WinUser { get; set; }
        public string WinPassWord { get; set; }
    }

    public class Accessmdb
    {
        public string FilePath { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public List<string> Tables { get; set; }
    }

    public class Sqlserver
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Security { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public List<string> Tables { get; set; }
    }

}
