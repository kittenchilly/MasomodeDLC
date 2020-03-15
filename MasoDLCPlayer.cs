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
		public bool rubberWeapon;

		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			RubberWeaponEffect(null, target, ref damage);
		}

		public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			RubberWeaponEffect(null, target, ref damage);
		}

		public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit)
		{
			RubberWeaponEffect(target, null, ref damage);
		}

		public override void ModifyHitPvpWithProj(Projectile proj, Player target, ref int damage, ref bool crit)
		{
			RubberWeaponEffect(target, null, ref damage);
		}
		public void RubberWeaponEffect(Player player, NPC npc, ref int damage)
		{
			int rand = Main.rand.Next(7);
			string squeak = "/squeak" + rand;
			if (rubberWeapon && npc == null)
			{
				damage = 0;
				player.statLife += 1;
				player.HealEffect(1, true);
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "FargowiltasSouls/Sounds/SqueakyToy" + squeak), player.Center);
			}
			else if (rubberWeapon && player == null)
			{
				damage = 0;
				npc.life += 1;
				npc.HealEffect(1, true);
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "FargowiltasSouls/Sounds/SqueakyToy" + squeak), npc.Center);
			}
		}

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
			rubberWeapon = false;
		}
		public override void UpdateDead()
		{
			teslasurgeplayer = false;
			rubberWeapon = false;
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