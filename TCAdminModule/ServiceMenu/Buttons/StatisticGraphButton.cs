﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCAdminModule.API;
using TCAdminModule.Modules;
using TCAdminModule.Objects;

namespace TCAdminModule.ServiceMenu.Buttons
{
    public class StatisticGraphButton : NexusServiceMenuModule
    {
        public StatisticGraphButton()
        {
            this.Name = "Statistics Graph Button";
            var attribute =
                new ActionCommandAttribute("Statistics", "View graphs of statistics of your server", ":GameStats:",
                    new List<string> {"PlayerStats", "CpuStats", "MemoryStats"},
                    true);
            this.ViewOrder = 6;
            this.ActionCommandAttribute = attribute;
        }

        public override async Task DoAction()
        {
            await base.DoAction();
            await CommandContext.TriggerTypingAsync();

            var chartType = await TcAdminUtilities.GetGraphType(CommandContext);

            try
            {
                await TcAdminUtilities.SendGraph(CommandContext, this.Authentication.Service, chartType);
            }
            catch (Exception e)
            {
                await CommandContext.RespondAsync(e.Message);
                await CommandContext.RespondAsync(e.StackTrace);
            }
        }
    }
}