using TShockAPI;
using Terraria;
using TerrariaApi.Server;
using System.Configuration;

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

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                // Unregister the handlers
            }
        }
    }

}

