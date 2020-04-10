using Terraria;
using Terraria.ModLoader;

namespace MasomodeDLC.Calamity.Buffs
{
    public class ArcaneShock : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Arcane Shock");
            Description.SetDefault("Static electric energy flows through you");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MasoDLCPlayer>().ArcaneShock = true;
        }
    }
}
