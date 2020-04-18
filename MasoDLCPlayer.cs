using System;
using System.Reflection;
using MasomodeDLC.Calamity.Buffs;
using MasomodeDLC.Thorium.Buffs;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace MasomodeDLC
{
	public class MasoDLCPlayer : ModPlayer
	{
        //references
        public bool IsStandingStill;
        public int MinuteTimer = 60;

		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		//private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		#region Buff/effect flags
		#region Thorium
		public bool teslasurge;
		public bool rubberWeapon;
		public bool wristpain;
		public bool creativeblank;
		public bool displayClouds;
		public bool abyssalDrag;
        #endregion
        #region Calamity
        //calamity debuffs
        public bool ArcaneShock;
        public bool voidVessel;
		public bool antimatterDoll;
		#endregion
		#endregion

		public override void ResetEffects()
		{
            //debuffs
            ArcaneShock = false;
			teslasurge = false;
			rubberWeapon = false;
			wristpain = false;
			creativeblank = false;
			displayClouds = false;
			abyssalDrag = false;

			voidVessel = false;
			antimatterDoll = false;
		}

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
				ModPlayer calPlayer = player.GetModPlayer(Calamity, "CalamityPlayer");
				FieldInfo field = calPlayer.GetType().GetField("ZoneSunkenSea");
				var zoneSunkenSea = field.GetValue(calPlayer); // for getting the value of the field
				if ((bool)zoneSunkenSea && player.wet)
				{
					player.AddBuff(Main.hardMode ? ModContent.BuffType<ForcedZen>() : ModContent.BuffType<ForcedPeace>(), 2);
				}
			}
			if (Thorium != null)
			{
				ModPlayer thoriumPlayer = player.GetModPlayer(Thorium, "ThoriumPlayer");
				FieldInfo field = thoriumPlayer.GetType().GetField("ZoneAqua");
				var zoneAquaticDepths = field.GetValue(thoriumPlayer); // for getting the value of the field
				if ((bool)zoneAquaticDepths && !ThorWorldBools.DownedJellyfishJam)
				{
					player.AddBuff(ModContent.BuffType<DontGoIntoTheFuckingAquaticDepthsBeforeQueen>(), 2); //hahayes
					player.AddBuff(BuffID.NoBuilding, 2);
				}
				if (player.ZoneJungle && !ThorWorldBools.DownedCoolBloomFacts)
				{
					player.AddBuff(ThorBuffIDs.TaintedHearts, 2);
				}
			}
		}

		public override void PostUpdateRunSpeeds()
		{
			#region Thorium
			if (Thorium != null)
			{
				if (player.HasBuff(ThorBuffIDs.Freezing))
				{
					player.runAcceleration /= 2f;
					player.maxRunSpeed *= 0.666666666f;
				}
				if (player.HasBuff(ModContent.BuffType<Teslasurge>()))
				{
					for (int i = 0; i < 60; i++)
					{
						player.maxRunSpeed += Main.rand.NextFloat(-0.25f, 0.25f);
					}
				}
				if (player.HasBuff(ModContent.BuffType<DontGoIntoTheFuckingAquaticDepthsBeforeQueen>()))
				{
					player.maxRunSpeed = 0.6f;
					player.maxFallSpeed += 1f;
					//how are we supposed to restrict vertical movement effectively - plant
					player.velocity.Y += 0.333f;
					// Something like that for now, will look further into this later  -Thomas
					// uh ok sure - plant
				}
			}
			#endregion
			#region Calamity
			if (Calamity != null)
			{

			}
			#endregion
		}

		public override void UpdateDead()
		{
            ArcaneShock = false;
			teslasurge = false;
			rubberWeapon = false;
			wristpain = false;
			creativeblank = false;
			displayClouds = false;
			abyssalDrag = false;
		}

        public override void PreUpdate()
        {
            IsStandingStill = Math.Abs(player.velocity.X) == 0 && Math.Abs(player.velocity.Y) == 0;
        }

        public override void UpdateBadLifeRegen()
		{
            if (ArcaneShock)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 20;
                if (!IsStandingStill)
                {
                    player.lifeRegen -= 200;
                }
            }
			if (teslasurge)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 8;
			}
			if (abyssalDrag && !player.wet)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 16000000; // literally death
			}
		}

		public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			if (teslasurge)
			{
				//todo: tesla effects
			}
		}

		bool doCooldown = true;
		int cloudTime = 0;
		int coolDown = 0;

		public override void PostUpdate()
		{
			if (displayClouds && Main.netMode != NetmodeID.Server && !Filters.Scene["CloudFilter"].IsActive())
			{
				Filters.Scene.Activate("CloudFilter", player.Center).GetShader().UseColor(1f, 1f, 1f).UseIntensity(80f).UseOpacity(0.95f);
			}
			else if (displayClouds && Main.netMode != NetmodeID.Server && Filters.Scene["CloudFilter"].IsActive())
			{
				doCooldown = true;
				cloudTime++;
				Filters.Scene["CloudFilter"].GetShader().UseProgress(cloudTime).UseTargetPosition(player.Center).UseOpacity(0.95f);
			}
			if (doCooldown && !displayClouds && Main.netMode != NetmodeID.Server)
			{
				coolDown++;
				float progress = coolDown / 60f;
				Filters.Scene["CloudFilter"].GetShader().UseProgress(progress).UseTargetPosition(player.Center).UseIntensity(80f - (progress * 80f)).UseOpacity(0.95f);
				if (coolDown >= 60)
				{
					Filters.Scene["CloudFilter"].Deactivate();
					cloudTime = 0;
					coolDown = 0;
					doCooldown = false;
				}
			}
		}
	}
}