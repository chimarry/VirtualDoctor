﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmbulanceDatabase.Config {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Properties : global::System.Configuration.ApplicationSettingsBase {
        
        private static Properties defaultInstance = ((Properties)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Properties())));
        
        public static Properties Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("server = localhost; port = 3306; database = ambulance; uid = root; password = mar" +
            "ija97;")]
        public string Ambulance {
            get {
                return ((string)(this["Ambulance"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(",")]
        public char GroupConcatSeparator {
            get {
                return ((char)(this["GroupConcatSeparator"]));
            }
        }
    }
}