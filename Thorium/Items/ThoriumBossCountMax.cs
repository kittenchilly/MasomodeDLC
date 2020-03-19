using FargowiltasSouls;
using Terraria;
using Terraria.ModLoader;

namespace MasomodeDLC.Thorium.Items
{
    public class ThoriumBossCountMax : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override string Texture => "FargowiltasSouls/Items/Placeholder";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorium Boss Count Max");
            Tooltip.SetDefault(@"Maximizes all boss kill counts
Results not guaranteed in multiplayer
You probably shouldn't be reading this...");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = 1;
            item.useStyle = 4;
            item.useAnimation = 45;
            item.useTime = 45;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            if (DLCConfig.MasoDLCmenu.instance.DevItemsNoFunction == false)
            {
                if (player.itemAnimation > 0 && player.itemTime == 0)
                {
                    MasoDLCWorld.ThunderBirdCount = FargoSoulsWorld.MaxCountPreHM;
                    MasoDLCWorld.JellyCount = FargoSoulsWorld.MaxCountPreHM;
                    MasoDLCWorld.VisCount = FargoSoulsWorld.MaxCountPreHM;
                    MasoDLCWorld.GraniteCount = FargoSoulsWorld.MaxCountPreHM;
                    MasoDLCWorld.ChampionCount = FargoSoulsWorld.MaxCountPreHM;
                    MasoDLCWorld.ScouterCount = FargoSoulsWorld.MaxCountPreHM;

                    MasoDLCWorld.StriderCount = FargoSoulsWorld.MaxCountHM;
                    MasoDLCWorld.BeholderCount = FargoSoulsWorld.MaxCountHM;
                    MasoDLCWorld.LichCount = FargoSoulsWorld.MaxCountHM;
                    MasoDLCWorld.AbyssionCount = FargoSoulsWorld.MaxCountHM;
                    MasoDLCWorld.RagnarokCount = FargoSoulsWorld.MaxCountHM;
                    Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
                }
                return true;
            }
            return false;
        }
    }
}