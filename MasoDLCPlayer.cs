using CalamityMod.CalPlayer;
using MasomodeDLC.Calamity.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace MasomodeDLC
{
    public class MasoDLCPlayer : ModPlayer
    {
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");

		public override void PostUpdateBuffs()
		{
			if (Calamity != null)
			{
				if (player.GetModPlayer<CalamityPlayer>().ZoneSunkenSea && player.wet)
				{
					player.AddBuff(Main.hardMode ? ModContent.BuffType<ForcedZen>() : ModContent.BuffType<ForcedPeace>(), 2);
				}
			}
		}

		public override void PostUpdateRunSpeeds()
		{
			if (Thorium != null)
			{
				if (player.HasBuff(Thorium.BuffType("EnemyFrozen")))
				{
					player.runAcceleration /= 2f;
					player.maxRunSpeed *= 0.666666666f;
				}
			}

			if (Calamity != null)
			{
			}
		}
	}
}