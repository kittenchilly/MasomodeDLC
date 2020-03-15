using CalamityMod.CalPlayer;
using MasomodeDLC.Calamity.Buffs;
using MasomodeDLC.Thorium.Buffs;
using ThoriumMod.Buffs;
using Terraria;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.ID;

namespace MasomodeDLC
{
    public class MasoDLCPlayer : ModPlayer
    {
		public int MinuteTimer = 60;

		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");

		public bool teslasurgeplayer;

		public override void PostUpdateBuffs()
		{
			if (Calamity != null)
			{
				if (player.GetModPlayer<CalamityPlayer>().ZoneSunkenSea && player.wet)
				{
					player.AddBuff(Main.hardMode ? ModContent.BuffType<ForcedZen>() : ModContent.BuffType<ForcedPeace>(), 2);
				}
			}
			if (Thorium != null)
			{
				if (player.GetModPlayer<ThoriumPlayer>().ZoneAqua && ThoriumWorld.downedJelly)
				{
					//TODO: Abyssal Drag inflict
					player.AddBuff(BuffID.NoBuilding, 2);
				}
				if (player.ZoneJungle && !ThoriumWorld.downedBloom)
				{
					player.AddBuff(ModContent.BuffType<PoisonHeart>(), 2);
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
				if (player.HasBuff(mod.BuffType("Teslasurge")))
				{
					if (MinuteTimer == 60)
					{
						player.maxRunSpeed -= Main.rand.NextFloat(0.01f, 0.2f);
					}
				}
			}

			if (Calamity != null)
			{

			}
		}
		public override void ResetEffects()
		{
			teslasurgeplayer = false;
		}
		public override void UpdateDead()
		{
			teslasurgeplayer = false;
		}
		public override void UpdateBadLifeRegen()
		{
			if (teslasurgeplayer)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 8;
			}
		}
		public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			if (teslasurgeplayer)
			{
				//todo: tesla effects
			}
		}
	}
}