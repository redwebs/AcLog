using System.Collections.Generic;
using Newtonsoft.Json;

namespace AclTrek
{
    public class AcLogSettings
    {
        public AppGeneralSettings AppGeneral { get; set; }
        public IList<AccessMdb> AccessMdbs { get; set; }
        public IList<SqlServer> SqlServers { get; set; }
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

    public class AccessMdb
    {
        public string FilePath { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public List<string> Tables { get; set; }
    }

    public class SqlServerDb
    {
        public string DatabaseName { get; set; }
        public string Security { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public List<string> Tables { get; set; }
    }
    public class SqlServer
    {
        public string ServerName { get; set; }
        public List<SqlServerDb> SqlServerDbs{ get; set; }
    }

}
