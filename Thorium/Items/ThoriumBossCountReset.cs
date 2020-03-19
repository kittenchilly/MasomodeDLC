using Terraria;
using Terraria.ModLoader;

namespace MasomodeDLC.Thorium.Items
{
    public class ThoriumBossCountReset : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override string Texture => "FargowiltasSouls/Items/Placeholder";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorium Boss Count Reset");
            Tooltip.SetDefault(@"Resets all boss kill counts to zero
Results not guaranteed in multiplayer
You probably shouldn't be reading this...");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = 1;
            if (DLCConfig.MasoDLCmenu.instance.DevItemsNoFunction == true)
            {
                item.useStyle = 4;
                item.useAnimation = 45;
                item.useTime = 45;
                item.consumable = true;
            }
        }

        public override bool UseItem(Player player)
        {
            if (DLCConfig.MasoDLCmenu.instance.DevItemsNoFunction == false)
            {
                if (player.itemAnimation > 0 && player.itemTime == 0)
                {
                    MasoDLCWorld.ThunderBirdCount = 0;
                    MasoDLCWorld.JellyCount = 0;
                    MasoDLCWorld.VisCount = 0;
                    MasoDLCWorld.GraniteCount = 0;
                    MasoDLCWorld.ChampionCount = 0;
                    MasoDLCWorld.ScouterCount = 0;
                    MasoDLCWorld.StriderCount = 0;
                    MasoDLCWorld.BeholderCount = 0;
                    MasoDLCWorld.LichCount = 0;
                    MasoDLCWorld.AbyssionCount = 0;
                    MasoDLCWorld.RagnarokCount = 0;
                    Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
                }
                return true;
            }
            return false;
        }
    }
}