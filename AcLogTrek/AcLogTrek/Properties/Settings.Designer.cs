﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AclTrek.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.2.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Set in log4net.config")]
        public string LogFilePath {
            get {
                return ((string)(this["LogFilePath"]));
            }
            set {
                this["LogFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\fred\\Dropbox\\HamLog\\LogData.mdb")]
        public string AccessMdbPath1 {
            get {
                return ((string)(this["AccessMdbPath1"]));
            }
            set {
                this["AccessMdbPath1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\FW\\Printpack\\COI\\Db\\Access\\Mdb\\COI_Admin_DB.mdb")]
        public string AccessMdbPath2 {
            get {
                return ((string)(this["AccessMdbPath2"]));
            }
            set {
                this["AccessMdbPath2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Work\\PPK\\Data\\COI_Admin_DB.mdb")]
        public string AccessMdbPath3 {
            get {
                return ((string)(this["AccessMdbPath3"]));
            }
            set {
                this["AccessMdbPath3"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("fredwebs.database.windows.net")]
        public string SqlServerName1 {
            get {
                return ((string)(this["SqlServerName1"]));
            }
            set {
                this["SqlServerName1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MERCURY\\MERCURY")]
        public string SqlServerName2 {
            get {
                return ((string)(this["SqlServerName2"]));
            }
            set {
                this["SqlServerName2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ppksql3dv")]
        public string SqlServerName3 {
            get {
                return ((string)(this["SqlServerName3"]));
            }
            set {
                this["SqlServerName3"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("AmateurContactLog")]
        public string SqlDbName1 {
            get {
                return ((string)(this["SqlDbName1"]));
            }
            set {
                this["SqlDbName1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COI_Sharepoint")]
        public string SqlDbName2 {
            get {
                return ((string)(this["SqlDbName2"]));
            }
            set {
                this["SqlDbName2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COI_Test")]
        public string SqlDbName3 {
            get {
                return ((string)(this["SqlDbName3"]));
            }
            set {
                this["SqlDbName3"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("pp_nt\\fpeters")]
        public string AccessMdbUserName {
            get {
                return ((string)(this["AccessMdbUserName"]));
            }
            set {
                this["AccessMdbUserName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Password1")]
        public string AccessMdbUserPW {
            get {
                return ((string)(this["AccessMdbUserPW"]));
            }
            set {
                this["AccessMdbUserPW"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("pp_nt\\fpeters")]
        public string WindowsUserName {
            get {
                return ((string)(this["WindowsUserName"]));
            }
            set {
                this["WindowsUserName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Password1")]
        public string WindowsUserPW {
            get {
                return ((string)(this["WindowsUserPW"]));
            }
            set {
                this["WindowsUserPW"] = value;
            }
        }
    }
}
