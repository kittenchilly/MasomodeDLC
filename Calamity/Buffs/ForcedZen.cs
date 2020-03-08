using Terraria;
using Terraria.ModLoader;

namespace MasomodeDLC.Calamity.Buffs
{
	public class ForcedZen : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Forced Zen");
			Description.SetDefault("Unwillingly experiencing tranquility");
			Main.debuff[Type] = false;
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