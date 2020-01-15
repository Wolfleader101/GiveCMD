using System;
using System.Linq;

namespace Oxide.Plugins
{
	[Info("Give command", "Wolfleader101", "0.0.1")]
	[Description("A Command that allows the user to give themselves any item")]

	public class GiveCMD : RustPlugin
	{
        // On Plugin Loaded
        void Loaded()
        {
            PrintToChat("Give Item Plugin has been Loaded");
        }

        [ChatCommand("give")]
        void GiveItem(BasePlayer player, string command, string[] args)
        {
            var name = args[0];
            var item = ItemManager.itemList.FirstOrDefault(x => x.displayName.english.ToLower().Contains(name)); // TODO get this working
            
            int amount = Int32.Parse(args[1]);
            
            player.SendMessage($"Spawned in {amount} x of {item}");
            player.inventory.GiveItem(ItemManager.CreateByName(name, amount));
            
        }
    }
}
