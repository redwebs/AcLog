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
        public AppGeneral ApplicationSettings { get; set; }
        public Accessmdb[] AccessMdbArray { get; set; }
        public Sqlserver[] SqlServerArray { get; set; }
        public Windowsuser WindowsUserSettings { get; set; }
    }

    public class AppGeneral
    {
        public string LogFilePath { get; set; }
    }

    public class Windowsuser
    {
        public string WinUser { get; set; }
        public string WinPassWord { get; set; }
    }

    public class Accessmdb
    {
        public string FilePath { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string[] Table { get; set; }
    }

    public class Sqlserver
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Security { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string[] Table { get; set; }
    }

}
