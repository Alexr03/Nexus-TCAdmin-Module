﻿using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Nexus.SDK.Modules;
using TCAdminModule.Attributes;
using TCAdminModule.Helpers;
using TCAdminModule.Services;

namespace TCAdminModule.Commands.Client
{
    public class LinkCommands : NexusCommandModule
    {
        [Command("Link")]
        [Aliases("Setup")]
        [Description("Link a game server")]
        [CommandAttributes.RequireAdministrator]
        [Cooldown(1, 30.00, CooldownBucketType.Guild)]
        public async Task LinkServiceTask(CommandContext ctx)
        {
            var user = await AccountsService.GetUser(ctx);
            var service = await DiscordService.LinkService(ctx, user);

            await ctx.RespondAsync(embed: EmbedTemplates.CreateSuccessEmbed(service.Name, "Link Successful!"));
        }
    }
}