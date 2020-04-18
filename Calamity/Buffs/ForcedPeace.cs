using Terraria;
using Terraria.ModLoader;

namespace MasomodeDLC.Calamity.Buffs
{
	public class ForcedPeace : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Forced Peace");
			Description.SetDefault("sanctuary");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			Main.buffNoTimeDisplay[Type] = player.buffTime[buffIndex] >= 18000;
		}
	}
}