using ClearNick;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Permissions;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;

public class NameCleanerPlugin : RocketPlugin<Configuration>
{
    protected override void Load()
    {
        UnturnedPermissions.OnJoinRequested += UnturnedPermissions_OnJoinRequested;
        Rocket.Core.Logging.Logger.Log("Clear nick is load! \nDeveloper discord: makcarosh")
    }

    protected override void Unload()
    {
        UnturnedPermissions.OnJoinRequested -= UnturnedPermissions_OnJoinRequested;
        Rocket.Core.Logging.Logger.Log("Clear nick is unload! \nDeveloper discord: makcarosh")
    }
    
    private void UnturnedPermissions_OnJoinRequested(CSteamID player, ref ESteamRejection? rejectionReason)
    {
        SteamPending steamPending = Provider.pending.FirstOrDefault((SteamPending p) => p.playerID.steamID.m_SteamID == player.m_SteamID);

        var config = Configuration.Instance;
        List<string> tags = config.tags;   
        string name = steamPending.playerID.characterName;
        

        foreach (string tag in tags)
        {
            int index = name.IndexOf(tag, StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                string cleaned = name.Remove(index, tag.Length).Trim();

                steamPending.playerID.characterName = cleaned;
            }
        }
    }
}
