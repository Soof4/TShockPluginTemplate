using Terraria;
using TShockAPI;

namespace TShockPluginTemplate
{
    public class Commands
    {
        public static void InitializeCommands()
        {
            TShockAPI.Commands.ChatCommands.Add(new Command("tshockplugintemplate.permissionname", ExampleCmd, "example", "eg"));
        }

        private static void ExampleCmd(CommandArgs args) {
            args.Player.SendSuccessMessage("Hello World!");
        }
    }
}