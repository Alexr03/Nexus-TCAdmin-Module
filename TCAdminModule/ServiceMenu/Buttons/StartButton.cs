﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TCAdmin.GameHosting.SDK.Objects;
using TCAdminModule.Modules;
using TCAdminModule.Objects;

namespace TCAdminModule.ServiceMenu.Buttons
{
    public class StartModule : NexusServiceMenuModule
    {
        public StartModule()
        {
            this.Name = "Start Button";
            var attribute =
                new ActionCommandAttribute("Start", "Start Server", ":arrow_forward:", new List<string> {"StartStop"},
                    false);
            this.ViewOrder = 1;
            this.ActionCommandAttribute = attribute;
        }

        public override async Task DoAction()
        {
            await base.DoAction();
            Service service = this.Authentication.Service;
            service.Start("Started by Nexus.");
            await CommandContext.RespondAsync($"**{service.NameNoHtml} has been started**");
        }
    }
}