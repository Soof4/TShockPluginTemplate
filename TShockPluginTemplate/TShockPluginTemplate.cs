using TShockAPI;
using Terraria;
using TerrariaApi.Server;
using Microsoft.Data.Sqlite;

namespace TShockPluginTemplate
{
    [ApiVersion(2, 1)]
    public class TShockPluginTemplate : TerrariaPlugin
    {
        public override string Name => "TShockPluginTemplate";
        public override string Author => "Soofa";
        public override string Description => "Description";
        public override Version Version => new Version(1, 0, 0);
        public TShockPluginTemplate(Main game) : base(game) { }

        public static Configuration Config = Configuration.Reload();
        public static DatabaseManager DBManager = new DatabaseManager(new SqliteConnection("Data Source=" + DatabaseManager.DatabasePath));

        public override void Initialize()
        {
            Handlers.InitializeHandlers(this);
            Commands.InitializeCommands();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                Handlers.DisposeHandlers(this);
            }
        }
    }
}

