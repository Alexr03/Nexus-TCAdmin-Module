﻿using System.Configuration;
using DSharpPlus;
using Nexus.SDK.Modules;
using TCAdminWrapper;

namespace TCAdminModule
{
    public class TcAdminModule : NexusAssemblyModule
    {
        public TcAdminModule()
        {
            this.Name = "TCAdmin Module";
            TCAdmin.SDK.Utility.AppSettings = ConfigurationManager.AppSettings;
            RegisterToTcAdmin();
        }

        private void RegisterToTcAdmin()
        {
            var moduleConfig = new NexusModuleConfiguration<TcAdminModuleConfig>("TCAdminModuleConfig.json").GetConfiguration();

            TCAdminSettings settings = new TCAdminSettings(true, moduleConfig.DebugTcAdmin, moduleConfig.DebugTcAdminSql);
            TCAdminClientConfiguration config = new TCAdminClientConfiguration(moduleConfig.SqlString,
                moduleConfig.SqlEncrypted, "TCAdminModule", settings);
            TcAdminClient client = new TcAdminClient(config);
            
            client.SetAppSettings();
        }
    }
}