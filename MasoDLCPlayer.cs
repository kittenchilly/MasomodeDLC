using CalamityMod.CalPlayer;
using MasomodeDLC.Calamity.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using ThoriumMod.Buffs;

namespace MasomodeDLC
{
	public class MasoDLCPlayer : ModPlayer
	{
		public int MinuteTimer = 60;

		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		//private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		#region Buff Bools
		public bool teslasurge;
		public bool rubberWeapon;
		public bool wristpain;
		public bool creativeblank;
		#endregion

		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			if (rubberWeapon)
			{
				damage = 0;
				RubberWeaponEffect(null, target);
			}
		}

		public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (rubberWeapon)
			{
				damage = 0;
				RubberWeaponEffect(null, target);
			}
		}

		public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit)
		{
			if (rubberWeapon)
			{
				damage = 0;
				RubberWeaponEffect(target, null);
			}
		}

		public override void ModifyHitPvpWithProj(Projectile proj, Player target, ref int damage, ref bool crit)
		{
			if (rubberWeapon)
			{
				damage = 0;
				RubberWeaponEffect(target, null);
			}
		}
		public void RubberWeaponEffect(Player player, NPC npc)
		{
			int rand = Main.rand.Next(7);
			string squeak = "/squeak" + rand;
			if (npc == null)
			{
				player.statLife += 1;
				player.HealEffect(1, true);
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "FargowiltasSouls/Sounds/SqueakyToy" + squeak), player.Center);
			}
			else if (player == null)
			{
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
					for (int i = 60; i == 0; i--)
					{
						player.maxRunSpeed += Main.rand.NextFloat(-0.25f, 0.25f);
					}
				}
			}

			if (Calamity != null)
			{

			}
		}
		public override void ResetEffects()
		{
			teslasurge = false;
			rubberWeapon = false;
			wristpain = false;
			creativeblank = false;
			
		}
		public override void UpdateDead()
		{
			teslasurge = false;
			rubberWeapon = false;
			wristpain = false;
			creativeblank = false;
		}
		public override void UpdateBadLifeRegen()
		{
			if (teslasurge)
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
			if (teslasurge)
			{
				//todo: tesla effects
			}
		}
	}
}