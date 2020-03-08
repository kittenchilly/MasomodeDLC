using FargowiltasSouls;
using FargowiltasSouls.Buffs.Masomode;
using FargowiltasSouls.NPCs;
using FargowiltasSouls.Projectiles.Masomode;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Buffs;
using ThoriumMod.NPCs;
using ThoriumMod.NPCs.Bat;
using ThoriumMod.NPCs.Beholder;
using ThoriumMod.NPCs.Blizzard;
using ThoriumMod.NPCs.Buried;
using ThoriumMod.NPCs.Contracts;
using ThoriumMod.NPCs.Depths;
using ThoriumMod.NPCs.EndofDays;
using ThoriumMod.NPCs.Granite;
using ThoriumMod.NPCs.Lich;
using ThoriumMod.NPCs.QueenJelly;
using ThoriumMod.NPCs.Scouter;
using ThoriumMod.NPCs.Thunder;
using ThoriumMod.Projectiles.Boss;
using static Terraria.ModLoader.ModContent;

namespace MasomodeDLC.Thorium
{
	public class ThoriumGlobalNPC : GlobalNPC
	{
		public override bool Autoload(ref string name)
		{
			return ModLoader.GetMod("ThoriumMod") != null;
		}

		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
		private readonly Mod FargoSouls = ModLoader.GetMod("FargowiltasSouls");
		public bool[] masoBool = new bool[4];
		private int Stop = 0;
		public int Counter = 0;
		public int Counter2 = 0;
		public int CachedDamage;
		public int lastPlayerAttack;

		public override bool InstancePerEntity => true;

		public static int boss = -1;
		public static int birdBoss = -1;
		public static int jellyfishBoss = -1;
		public static int viscountBoss = -1;
		public static int graniteBoss = -1;
		public static int buriedBoss = -1;
		public static int scouterBoss = -1;
		public static int striderBoss = -1;
		public static int coznixBoss = -1;
		public static int lichBoss = -1;
		public static int abyssBoss = -1;
		public static int aquaBoss = -1;
		public static int omniBoss = -1;
		public static int slagBoss = -1;
		public static int ragBoss = -1;

		public override void SetDefaults(NPC npc)
		{
			FargoSoulsGlobalNPC fargoSoulsGlobalNPC = npc.GetGlobalNPC<FargoSoulsGlobalNPC>();

			if (FargoSoulsWorld.MasochistMode)
			{
				if (ThoriumNPC(npc))
				{
					#region Bosses
					if (npc.type == NPCType<ThePrimeScouter>()
					 || npc.type == NPCType<PyroCore>()
					 || npc.type == NPCType<BioCore>()
					 || npc.type == NPCType<CryoCore>())
					{
						npc.buffImmune[BuffID.Suffocation] = true;
					}

					if (npc.type == NPCType<FallenDeathBeholder>()
					 || npc.type == NPCType<FallenDeathBeholder2>()
					 || npc.type == NPCType<EnemyBeholder>())
					{
						npc.buffImmune[BuffID.OnFire] = true;
					}
					#endregion
					#region Everything else
					if (npc.type == NPCType<Barracuda>()
					 || npc.type == NPCType<Blowfish>()
					 || npc.type == NPCType<GigaClam>()
					 || npc.type == NPCType<Globee>()
					 || npc.type == NPCType<Hammerhead>()
					 || npc.type == NPCType<ManofWar>()
					 || npc.type == NPCType<MorayHead>() || npc.type == NPCType<MorayBody>() || npc.type == NPCType<MorayTail>()
					 || npc.type == NPCType<Octopus>()
					 || npc.type == NPCType<Sharptooth>()
					 || npc.type == NPCType<AbyssalAngler2>()
					 || npc.type == NPCType<AquaticHallucination>()
					 || npc.type == NPCType<Blobfish>()
					 || npc.type == NPCType<CrownofThorns>()
					 || npc.type == NPCType<FeedingFrenzy>() || npc.type == NPCType<FeedingFrenzy2>()
					 || npc.type == NPCType<Kraken>()
					 || npc.type == NPCType<PutridSerpent>()
					 || npc.type == NPCType<DepthMimic>()
					 || npc.type == NPCType<Whale>()
					 || npc.type == NPCType<VampireSquid>()
					 || npc.type == NPCType<EelHead>() || npc.type == NPCType<EelBody>() || npc.type == NPCType<EelTail>())
					{
						fargoSoulsGlobalNPC.isWaterEnemy = true;
					}

					if (npc.type == NPCType<SnowBall>()
					 || npc.type == NPCType<SnowEater>()
					 || npc.type == NPCType<SnowElemental>()
					 || npc.type == NPCType<SnowSinga>()
					 || npc.type == NPCType<SnowyOwl>()
					 || npc.type == NPCType<FrostBurnt>()
					 || npc.type == NPCType<FrostBurntFlayer>()
					 || npc.type == NPCType<FrostFang>()
					 || npc.type == NPCType<FrostFangWall>()
					 || npc.type == NPCType<BlizzardBat>()
					 || npc.type == NPCType<IceBoulderMimic>()
					 || npc.type == NPCType<FrostyWisp>()
					 || npc.type == NPCType<ChilledCannon>()
					 || npc.type == NPCType<ChilledSpitter>()
					 || npc.type == NPCType<Freezer>()
					 || npc.type == NPCType<FrostWormHead>() || npc.type == NPCType<FrostWormBody>() || npc.type == NPCType<FrostWormTail>()
					 || npc.type == NPCType<Coolmera>()
					 || npc.type == NPCType<FrozenFace>()
					 || npc.type == NPCType<FrozenGross>()
					 || npc.type == NPCType<Coldling>())

					if (npc.type == NPCType<Nestling>()
					 || npc.type == NPCType<WindElemental>()
					 || npc.type == NPCType<CyanHag>())
					{
						npc.buffImmune[BuffID.Suffocation] = true;
					}

					if (npc.type == NPCType<RedHag>()
					 || npc.type == NPCType<BoneFlayer>()
					 || npc.type == NPCType<InfernalHound>()
					 || npc.type == NPCType<RedHag>()
					 || npc.type == NPCType<MoltenBoulderMimic>()
					 || npc.type == NPCType<RedHag>()
					 || npc.type == NPCType<MoltenMortar>()
					 || npc.type == NPCType<UnderworldPot1>()
					 || npc.type == NPCType<HellBringerMimic>()
					)
					{
						npc.buffImmune[BuffID.OnFire] = true;
					}

					if (npc.type == NPCType<GoblinSpiritGuide>()
					 || npc.type == NPCType<ShadowflameRevenant>())
					{
						if (!Main.hardMode)
						{
							npc.lifeMax /= 2;
							npc.damage /= 2;
						}
					}
					#endregion
				}
			}
		}

		public override void ScaleExpertStats(NPC npc, int numPlayers, float bossLifeScale)
		{
			if (FargoSoulsWorld.MasochistMode)
			{
				if (ThoriumNPC(npc))
				{
					if
					(
					npc.type == NPCType<TheGrandThunderBirdv2>() ||
					npc.type == NPCType<Hatchling>()
					)
					{
						npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.ThunderBirdCount * .025));
						npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ThunderBirdCount * .0125));
					}
					else if
					(
					npc.type == NPCType<QueenJelly>() ||
					npc.type == NPCType<DistractJelly>() ||
					npc.type == NPCType<SpittingJelly>() ||
					npc.type == NPCType<ZealousJelly>()
					)
					{
						npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.JellyCount * .025));
						npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.JellyCount * .0125));
					}
					else if
					(
					npc.type == NPCType<Viscount>() ||
					npc.type == NPCType<ViscountBaby>()
					)
					{
						npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.VisCount * .025));
						npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.VisCount * .0125));
					}
					else if
					(
					npc.type == NPCType<GraniteEnergyStorm>() ||
					npc.type == NPCType<EncroachingEnergy>() ||
					npc.type == NPCType<EnergyBarrier>() ||
					npc.type == NPCType<EnergyCanduit>() ||
					npc.type == NPCType<GraniteEnergy>()
					)
					{
						npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.GraniteCount * .025));
						npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.GraniteCount * .0125));
					}
					else if
					(
					npc.type == NPCType<TheBuriedWarrior>() ||
					npc.type == NPCType<TheBuriedWarrior1>() ||
					npc.type == NPCType<TheBuriedWarrior2>() ||
					npc.type == NPCType<BuriedVolley>()
					)
					{
						npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.ChampionCount * .025));
						npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ChampionCount * .0125));
					}
					else if
					(
					npc.type == NPCType<ThePrimeScouter>() ||
					npc.type == NPCType<BioCore>() ||
					npc.type == NPCType<CryoCore>() ||
					npc.type == NPCType<PyroCore>()
					)
					{
						npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.ScouterCount * .025));
						npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ScouterCount * .0125));
					}
					else if
					(
					npc.type == NPCType<BoreanStrider>() ||
					npc.type == NPCType<BoreanStriderPopped>() ||
					npc.type == NPCType<BoreanMyte1>() ||
					npc.type == NPCType<BoreanHopper>()
					)
					{
						npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.StriderCount * .025));
						npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.StriderCount * .0125));
					}
					else if
					(
					npc.type == NPCType<FallenDeathBeholder>() ||
					npc.type == NPCType<FallenDeathBeholder2>() ||
					npc.type == NPCType<EnemyBeholder>()
					)
					{
						npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.BeholderCount * .025));
						npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.BeholderCount * .0125));
					}
					else if
					(
					npc.type == NPCType<Lich>() ||
					npc.type == NPCType<LichHeadless>() ||
					npc.type == NPCType<ThousandSoulPhalactry>()
					)
					{
						npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.LichCount * .025));
						npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.LichCount * .0125));
					}
					else if
					(
					npc.type == NPCType<Abyssion>() ||
					npc.type == NPCType<AbyssionCracked>() ||
					npc.type == NPCType<AbyssionReleased>() ||
					npc.type == NPCType<AbyssalSpawn>()
					)
					{
						npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.AbyssionCount * .025));
						npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.AbyssionCount * .0125));
					}
					else if
					(
					npc.type == NPCType<RealityBreaker>() ||
					npc.type == NPCType<Aquaius>() ||
					npc.type == NPCType<Aquaius2>() ||
					npc.type == NPCType<AquaiusBubble>() ||
					npc.type == NPCType<AquaiusBubblePrime>() ||
					npc.type == NPCType<AquaTitan>() ||
					npc.type == NPCType<BoundlessEntity>() ||
					npc.type == NPCType<DeathTitan>() ||
					npc.type == NPCType<DespairSpirit>() ||
					npc.type == NPCType<DreadSpirit>() ||
					npc.type == NPCType<OmegaSigil>() ||
					npc.type == NPCType<Omnicide>() ||
					npc.type == NPCType<RealityEaterHead>() ||
					npc.type == NPCType<RealityEaterBody>() ||
					npc.type == NPCType<RealityEaterTail>() ||
					npc.type == NPCType<SlagFury>() ||
					npc.type == NPCType<SlagTitan>()
					)
					{
						npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.RagnarokCount * .025));
						npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.RagnarokCount * .0125));
					}
					CachedDamage = npc.damage;
				}
			}
		}

		public override bool PreAI(NPC npc)
		{
			Player player = Main.player[npc.target];
			if (FargoSoulsWorld.MasochistMode)
			{
				if (ThoriumNPC(npc))
				{
					if (npc.type == NPCType<TheGrandThunderBirdv2>() && npc.boss == true)
					{
						birdBoss = npc.whoAmI;
						if (npc.ai[0] < 5f)
						{
							if (npc.ai[3] == 0)
							{
								if (npc.ai[2] > 59f && npc.ai[2] < 61f)
								{
									if (Main.rand.Next(2) == 0)
									{
										Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y, 8f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
									}
									else
									{
										Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
										Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y, 8f, 0f, ProjectileType<GrandThunderBirdZap>(), 0xC, 3f, 0xFF, 0f, 0f);
									}
								}
							}
							else if (npc.ai[3] == 1f)
							{
								if (npc.ai[2] > 300f)
								{
									Aura(npc, 200, BuffType<LightningRod>(), false, DustID.Electric);
								}
							}
							else if (npc.ai[3] == 2f)
							{
								if (npc.ai[2] > 59f && npc.ai[2] % 60f == 0f)
								{
									int npcToSpawn = NPCType<TheGrandThunderBirdv2>();
									int npcIndex = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 0xA, npcToSpawn, 0, (float)npc.whoAmI, 0f, 0f, 0f, 0xFF);
									Main.npc[npcIndex].whoAmI = npcIndex;
									NetMessage.SendData(23, -1, -1, null, npcIndex, 0f, 0f, 0f, 0, 0, 0);
									Main.npc[npcIndex].boss = false;
									Main.npc[npcIndex].scale = 0.5f;
									Main.npc[npcIndex].lifeMax = npc.lifeMax / 20;
									Main.npc[npcIndex].life = npc.lifeMax / 20;
									Main.npc[npcIndex].value = 0;
								}
								Aura(npc, 750, BuffID.Electrified, true, DustID.Electric);
							}
						}
					}
					if
					(
					npc.type == NPCType<QueenJelly>()
					)
					{
						jellyfishBoss = npc.whoAmI;
					}
					if
					(
					npc.type == NPCType<Viscount>()
					)
					{
						viscountBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<GraniteEnergyStorm>()
					)
					{
						graniteBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<TheBuriedWarrior>()
					)
					{
						buriedBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<ThePrimeScouter>()
					)
					{
						scouterBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<BoreanStrider>() ||
					npc.type == NPCType<BoreanStriderPopped>()
					)
					{
						striderBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<FallenDeathBeholder>() ||
					npc.type == NPCType<FallenDeathBeholder2>()
					)
					{
						coznixBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<Lich>() ||
					npc.type == NPCType<LichHeadless>()
					)
					{
						lichBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<Abyssion>() ||
					npc.type == NPCType<AbyssionCracked>() ||
					npc.type == NPCType<AbyssionReleased>()
					)
					{
						abyssBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<Aquaius>() ||
					npc.type == NPCType<AquaiusBubblePrime>() ||
					npc.type == NPCType<Aquaius2>()
					)
					{
						aquaBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<Omnicide>()
					)
					{
						omniBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<SlagFury>()
					)
					{
						slagBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<RealityBreaker>()
					)
					{
						ragBoss = npc.whoAmI;
					}
					else if
					(
					npc.type == NPCType<RealityBreaker>() ||
					npc.type == NPCType<Aquaius>() ||
					npc.type == NPCType<Aquaius2>() ||
					npc.type == NPCType<AquaiusBubble>() ||
					npc.type == NPCType<AquaiusBubblePrime>() ||
					npc.type == NPCType<AquaTitan>() ||
					npc.type == NPCType<BoundlessEntity>() ||
					npc.type == NPCType<DeathTitan>() ||
					npc.type == NPCType<DespairSpirit>() ||
					npc.type == NPCType<DreadSpirit>() ||
					npc.type == NPCType<OmegaSigil>() ||
					npc.type == NPCType<Omnicide>() ||
					npc.type == NPCType<RealityEaterHead>() ||
					npc.type == NPCType<RealityEaterBody>() ||
					npc.type == NPCType<RealityEaterTail>() ||
					npc.type == NPCType<SlagFury>() ||
					npc.type == NPCType<SlagTitan>()
					)
					{
						ragBoss = npc.whoAmI;
					}
					CachedDamage = npc.damage;

					if
					(
					npc.type == NPCType<GoblinDrummer>() ||
					npc.type == NPCType<GoblinSpiritGuide>() ||
					npc.type == NPCType<GoblinTrapper>() ||
					npc.type == NPCType<ShadowflameRevenant>()
					)
					{
						if (npc.HasPlayerTarget && (!Main.player[npc.target].active || Main.player[npc.target].dead))
						{
							npc.TargetClosest();
							if (npc.HasPlayerTarget && (!Main.player[npc.target].active || Main.player[npc.target].dead))
								npc.noTileCollide = true;
						}
					}
					if
					(
					npc.type == NPCType<HellBringerMimic>() ||
					npc.type == NPCType<MyceliumMimic>() ||
					npc.type == NPCType<DepthMimic>()
					)
					{
						if (masoBool[0])
						{
							if (npc.velocity.Y == 0f) //spawn smash
							{
								masoBool[0] = false;
								Main.PlaySound(2, npc.Center, 14);
								if (Main.netMode != 1)
								{
									Projectile.NewProjectile(npc.Center, Vector2.Zero, ProjectileID.DD2OgreSmash, npc.damage / 4, 4, Main.myPlayer);
									/*int type;
                                    if (npc.type == NPCID.BigMimicHallow)
                                        type = ProjectileID.HallowSpray;
                                    else if (npc.type == NPCID.BigMimicCorruption)
                                        type = ProjectileID.CorruptSpray;
                                    else if (npc.type == NPCID.BigMimicCrimson)
                                        type = ProjectileID.CrimsonSpray;
                                    else
                                        type = ProjectileID.PureSpray;
                                    const int max = 16;
                                    for (int i = 0; i < max; i++)
                                    {
                                        Vector2 vel = new Vector2(0f, -4f).RotatedBy(2 * Math.PI / max * i);
                                        Projectile.NewProjectile(npc.Center, vel, type, 0, 0f, Main.myPlayer, 8f);
                                    }*/
								}
							}
						}
						else if (npc.velocity.Y > 0 && npc.noTileCollide) //mega jump
						{
							masoBool[0] = true;
						}
						if (npc.position.Y < Main.worldSurface * 16)
						{
							if (++Counter > 300)
							{
								Counter = 0;
								masoBool[1] = !masoBool[1];
							}
							if (masoBool[1] && ++Counter2 > 6)
							{
								Counter2 = 0;
								if (npc.HasPlayerTarget)
								{
									Vector2 speed = Main.player[npc.target].Center - npc.Center;
									speed.X += Main.rand.Next(-80, 81);
									speed.Y += Main.rand.Next(-80, 81);
									speed.Normalize();
									speed *= 8f;
									if (Main.netMode != 1)
										Projectile.NewProjectile(npc.Center, speed, ProjectileType<MimicCoin>(), npc.damage / 5, 0f, Main.myPlayer, Main.rand.Next(3));

									Main.PlaySound(SoundID.Item11, npc.Center);
								}
							}
						}
					}
				}
			}
			return true;
		}

		public override void PostAI(NPC npc)
		{
			if (FargoSoulsWorld.MasochistMode)
			{
				if (ThoriumNPC(npc))
				{
					if (npc.damage != CachedDamage)
					{
						if
						(
						npc.type == NPCType<TheGrandThunderBirdv2>() ||
						npc.type == NPCType<Hatchling>()
						)
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ThunderBirdCount * .0125));
						}
						else if
						(
						npc.type == NPCType<QueenJelly>() ||
						npc.type == NPCType<DistractJelly>() ||
						npc.type == NPCType<SpittingJelly>() ||
						npc.type == NPCType<ZealousJelly>()
						)
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.JellyCount * .0125));
						}
						else if
						(
						npc.type == NPCType<Viscount>() ||
						npc.type == NPCType<ViscountBaby>()
						)
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.VisCount * .0125));
						}
						else if
						(
						npc.type == NPCType<GraniteEnergyStorm>() ||
						npc.type == NPCType<EncroachingEnergy>() ||
						npc.type == NPCType<EnergyBarrier>() ||
						npc.type == NPCType<EnergyCanduit>() ||
						npc.type == NPCType<GraniteEnergy>()
						)
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.GraniteCount * .0125));
						}

						if (npc.type == NPCType<TheBuriedWarrior>()
						 || npc.type == NPCType<TheBuriedWarrior1>()
						 || npc.type == NPCType<TheBuriedWarrior2>()
						 || npc.type == NPCType<BuriedVolley>()
						)
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ChampionCount * .0125));
						}

						if (npc.type == NPCType<ThePrimeScouter>()
						 || npc.type == NPCType<BioCore>()
						 || npc.type == NPCType<CryoCore>()
						 || npc.type == NPCType<PyroCore>())
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ScouterCount * .0125));
						}

						if (npc.type == NPCType<BoreanStrider>()
						 || npc.type == NPCType<BoreanStriderPopped>() 
						 || npc.type == NPCType<BoreanMyte1>()
						 || npc.type == NPCType<BoreanHopper>())
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.StriderCount * .0125));
						}
						else if
						(
						npc.type == NPCType<FallenDeathBeholder>() ||
						npc.type == NPCType<FallenDeathBeholder2>() ||
						npc.type == NPCType<EnemyBeholder>()
						)
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.BeholderCount * .0125));
						}
						else if
						(
						npc.type == NPCType<Lich>() ||
						npc.type == NPCType<LichHeadless>() ||
						npc.type == NPCType<ThousandSoulPhalactry>()
						)
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.LichCount * .0125));
						}
						if (npc.type == NPCType<Abyssion>()
						 || npc.type == NPCType<AbyssionCracked>()
						 || npc.type == NPCType<AbyssionReleased>()
						 || npc.type == NPCType<AbyssalSpawn>())
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.AbyssionCount * .0125));
						}

						if (npc.type == NPCType<RealityBreaker>()
						 || npc.type == NPCType<Aquaius>()
						 || npc.type == NPCType<Aquaius2>()
						 || npc.type == NPCType<AquaiusBubble>()
						 || npc.type == NPCType<AquaiusBubblePrime>()
						 || npc.type == NPCType<AquaTitan>()
						 || npc.type == NPCType<BoundlessEntity>()
						 || npc.type == NPCType<DeathTitan>()
						 || npc.type == NPCType<DespairSpirit>()
						 || npc.type == NPCType<DreadSpirit>()
						 || npc.type == NPCType<OmegaSigil>()
						 || npc.type == NPCType<Omnicide>()
						 || npc.type == NPCType<RealityEaterHead>()
						 || npc.type == NPCType<RealityEaterBody>()
						 || npc.type == NPCType<RealityEaterTail>()
						 || npc.type == NPCType<SlagFury>()
						 || npc.type == NPCType<SlagTitan>())
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.RagnarokCount * .0125));
						}
						CachedDamage = npc.damage;
					}
					if (npc.type == NPCType<TheGrandThunderBirdv2>() && npc.boss == true)
					{
						if (npc.ai[0] < 5f)
						{
							if (npc.ai[3] == 2f)
							{
								if (npc.ai[2] > 59f && npc.ai[2] % 60f == 0f)
								{
									for (int i = 0; i < Main.maxNPCs; i++)
									{
										if (Main.npc[i].type == NPCType<Hatchling>())
										{
											Main.npc[i].active = false;
											break;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
		{
			npc.GetGlobalNPC<ThoriumGlobalNPC>().lastPlayerAttack = player.whoAmI;
		}

		public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
		{
			npc.GetGlobalNPC<ThoriumGlobalNPC>().lastPlayerAttack = projectile.owner;
		}

		public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
		{
			if (FargoSoulsWorld.MasochistMode)
			{
				if (ThoriumNPC(npc))
				{
					if (npc.type == NPCType<TheGrandThunderBirdv2>())
					{
						if (npc.ai[2] > 300f && npc.boss == true)
						{
							target.AddBuff(BuffType<Staggered>(), 600);
							Vector2 velocity = Vector2.Normalize(target.Center - npc.Center) * 30;
							target.velocity = velocity;
						}
						target.AddBuff(BuffID.Electrified, 300);
					}

					if (npc.type == NPCType<Hatchling>())
					{
						target.AddBuff(BuffID.Electrified, 300);
					}

					if (npc.type == NPCType<Biter>())
					{
						target.AddBuff(BuffType<Rotting>(), 300);
					}

					if (npc.type == NPCType<GoblinDrummer>()
					 || npc.type == NPCType<GoblinSpiritGuide>()
					 || npc.type == NPCType<GoblinTrapper>()
					 || npc.type == NPCType<ShadowflameRevenant>())
					{
						if (Main.hardMode)
							target.AddBuff(BuffType<LivingWasteland>(), 600);
					}

					if (npc.type == NPCType<FrostBurnt>()
					 || npc.type == NPCType<FrostBurntFlayer>())
					{
						target.AddBuff(BuffID.Frostburn, 200);
						target.AddBuff(Thorium.BuffType("Freezing"), 100);
					}

					if (npc.type == NPCType<HellBringerMimic>())
					{
						target.AddBuff(BuffType<Berserked>(), 300);
						target.AddBuff(BuffType<Purified>(), 300);
						target.AddBuff(BuffID.OnFire, 300);
					}

					if (npc.type == NPCType<MyceliumMimic>())
					{
						target.AddBuff(BuffType<Berserked>(), 300);
						target.AddBuff(BuffType<Purified>(), 300);
						target.AddBuff(BuffID.Poisoned, 300);
					}

					if (npc.type == NPCType<DepthMimic>())
					{
						target.AddBuff(BuffType<Berserked>(), 300);
						target.AddBuff(BuffType<Purified>(), 300);
						//add unique buff here
					}

					if (npc.type == NPCType<FrostBurnt>()
					 || npc.type == NPCType<FrostBurntFlayer>())
					{
						target.AddBuff(BuffID.Frostburn, 240);
						target.AddBuff(BuffType<EnemyFrozen>(), 240);
					}
				}
				else
				{
					if (npc.type == NPCID.WalkingAntlion)
					{
						if (Math.Abs(npc.velocity.X) > 10)
						{
							float time = 10 * (Math.Abs(npc.velocity.X) - 10);
							target.AddBuff(BuffType<Staggered>(), (int)time);
						}
					}
					if (npc.type == NPCID.TombCrawlerHead)
					{
						target.AddBuff(BuffType<Staggered>(), 150);
					}
				}
			}
		}

		public override bool CheckDead(NPC npc)
		{
			if (FargoSoulsWorld.MasochistMode)
			{
				if (ThoriumNPC(npc))
				{
					if (npc.type == NPCType<TheGrandThunderBirdv2>() && npc.boss == true)
					{
						if (MasoDLCWorld.ThunderBirdCount < FargoSoulsWorld.MaxCountPreHM)
							MasoDLCWorld.ThunderBirdCount++;
					}
					else if (npc.type == NPCType<QueenJelly>())
					{
						if (MasoDLCWorld.JellyCount < FargoSoulsWorld.MaxCountPreHM)
							MasoDLCWorld.JellyCount++;
					}
					else if (npc.type == NPCType<Viscount>())
					{
						if (MasoDLCWorld.VisCount < FargoSoulsWorld.MaxCountPreHM)
							MasoDLCWorld.VisCount++;
					}
					else if (npc.type == NPCType<GraniteEnergyStorm>())
					{
						if (MasoDLCWorld.GraniteCount < FargoSoulsWorld.MaxCountPreHM)
							MasoDLCWorld.GraniteCount++;
					}
					else if (npc.type == NPCType<TheBuriedWarrior>())
					{
						if (MasoDLCWorld.ChampionCount < FargoSoulsWorld.MaxCountPreHM)
							MasoDLCWorld.ChampionCount++;
					}
					else if (npc.type == NPCType<ThePrimeScouter>())
					{
						if (MasoDLCWorld.ScouterCount < FargoSoulsWorld.MaxCountPreHM)
							MasoDLCWorld.ScouterCount++;
					}
					else if (npc.type == NPCType<BoreanStriderPopped>())
					{
						if (MasoDLCWorld.StriderCount < FargoSoulsWorld.MaxCountHM)
							MasoDLCWorld.StriderCount++;
					}
					else if (npc.type == NPCType<FallenDeathBeholder2>())
					{
						if (MasoDLCWorld.BeholderCount < FargoSoulsWorld.MaxCountHM)
							MasoDLCWorld.BeholderCount++;
					}
					else if (npc.type == NPCType<LichHeadless>())
					{
						if (MasoDLCWorld.LichCount < FargoSoulsWorld.MaxCountHM)
							MasoDLCWorld.LichCount++;
					}
					else if (npc.type == NPCType<AbyssionReleased>())
					{
						if (MasoDLCWorld.AbyssionCount < FargoSoulsWorld.MaxCountHM)
							MasoDLCWorld.AbyssionCount++;
					}
					else if (npc.type == NPCType<RealityBreaker>())
					{
						if (MasoDLCWorld.RagnarokCount < FargoSoulsWorld.MaxCountHM)
							MasoDLCWorld.RagnarokCount++;
					}
					if (npc.type == NPCType<GoblinDrummer>()
					 || npc.type == NPCType<GoblinSpiritGuide>()
					 || npc.type == NPCType<GoblinTrapper>()
					)
					{
						if (Main.netMode != 1)
							Projectile.NewProjectile(npc.Center, new Vector2(Main.rand.NextFloat(-2f, 2f), -5), ProjectileType<GoblinSpikyBall>(), 15, 0, Main.myPlayer);
					}
					if (npc.type == NPCType<HellBringerMimic>()
					 || npc.type == NPCType<MyceliumMimic>()
					 || npc.type == NPCType<DepthMimic>()
					)
					{
						if (Main.netMode != 1)
						{
							int max = 5;
							for (int i = 0; i < max; i++)
								Projectile.NewProjectile(npc.position.X + Main.rand.Next(npc.width), npc.position.Y + Main.rand.Next(npc.height),
									Main.rand.Next(-30, 31) * .1f, Main.rand.Next(-40, -15) * .1f, ProjectileType<FakeHeart>(), 20, 0f, Main.myPlayer);
						}
					}
				}
			}
			return true;
		}

		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		{
			//layers
			int y = spawnInfo.spawnTileY;
			bool cavern = y >= Main.maxTilesY * 0.4f && y <= Main.maxTilesY * 0.8f;
			bool underground = y > Main.worldSurface && y <= Main.maxTilesY * 0.4f;
			bool surface = y < Main.worldSurface && !spawnInfo.sky;
			bool wideUnderground = cavern || underground;
			bool underworld = spawnInfo.player.ZoneUnderworldHeight;
			bool sky = spawnInfo.sky;

			//times
			bool night = !Main.dayTime;
			bool day = Main.dayTime;
			bool rain = Main.raining;

			//biomes
			bool noBiome = MasomodeDLC.NoBiomeNormalSpawn(spawnInfo);
			bool ocean = spawnInfo.player.ZoneBeach;
			bool dungeon = spawnInfo.player.ZoneDungeon;
			bool meteor = spawnInfo.player.ZoneMeteor;
			bool spiderCave = spawnInfo.spiderCave;
			bool mushroom = spawnInfo.player.ZoneGlowshroom;
			bool jungle = spawnInfo.player.ZoneJungle;
			bool granite = spawnInfo.granite;
			bool marble = spawnInfo.marble;
			bool corruption = spawnInfo.player.ZoneCorrupt;
			bool crimson = spawnInfo.player.ZoneCrimson;
			bool snow = spawnInfo.player.ZoneSnow;
			bool hallow = spawnInfo.player.ZoneHoly;
			bool desert = spawnInfo.player.ZoneDesert;

			bool nebulaTower = spawnInfo.player.ZoneTowerNebula;
			bool vortexTower = spawnInfo.player.ZoneTowerVortex;
			bool stardustTower = spawnInfo.player.ZoneTowerStardust;
			bool solarTower = spawnInfo.player.ZoneTowerSolar;

			bool water = spawnInfo.water;

			//events
			bool nearInvasion = spawnInfo.invasion;
			bool goblinArmy = Main.invasionType == 1;
			bool frostLegion = Main.invasionType == 2;
			bool pirates = Main.invasionType == 3;
			bool oldOnesArmy = DD2Event.Ongoing && spawnInfo.player.ZoneOldOneArmy;
			bool frostMoon = surface && night && Main.snowMoon;
			bool pumpkinMoon = surface && night && Main.pumpkinMoon;
			bool solarEclipse = surface && day && Main.eclipse;
			bool martianMadness = Main.invasionType == 4;
			bool lunarEvents = NPC.LunarApocalypseIsUp && (nebulaTower || vortexTower || stardustTower || solarTower);
			bool monsterMadhouse = MMWorld.MMArmy;

			//no work?
			//is lava on screen
			bool nearLava = Collision.LavaCollision(spawnInfo.player.position, spawnInfo.spawnTileX, spawnInfo.spawnTileY);
			bool noInvasion = MasomodeDLC.NoInvasion(spawnInfo);
			bool normalSpawn = !spawnInfo.playerInTown && noInvasion && !oldOnesArmy;

			bool sinisterIcon = spawnInfo.player.GetModPlayer<FargoPlayer>().SinisterIcon;

			if (FargoSoulsWorld.MasochistMode)
			{
				if (Thorium != null)
				{
					if (!Main.hardMode)
					{
						if (goblinArmy && nearInvasion)
						{
							pool[NPCType<GoblinSpiritGuide>()] = ((double)spawnInfo.spawnTileY < Main.worldSurface) ? 0.1f : 0f;
						}

						if (surface)
						{
							if (ThoriumMod.ThoriumWorld.downedThunderBird)
							{
								if (desert)
								{
									pool[NPCType<Hatchling>()] = 0.1f;
								}
							}
							if (NPC.downedBoss1)
							{
								if (desert && rain && !sinisterIcon && !FargoSoulsGlobalNPC.AnyBossAlive())
								{
									pool[NPCType<TheGrandThunderBirdv2>()] = .002f;
								}
							}
						}
					}
				}
			}
		}

		public override bool PreNPCLoot(NPC npc)
		{
			Player player = Main.player[npc.GetGlobalNPC<ThoriumGlobalNPC>().lastPlayerAttack];
			if (npc.type == NPCType<FrostBurnt>()
			 || npc.type == NPCType<FrostBurntFlayer>())
			{
				if (player.GetModPlayer<FargoPlayer>().TimsConcoction)
					RunItemDropOnce(npc, Thorium.ItemType("FrostHeartPotion"), 1, false, 1, 4);
			}
			if (npc.type == NPCType<TheGrandThunderBirdv2>() && npc.boss == false)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// Drops the specified item if the chance to drop succeeds, defaults to a guaranteed drop.
		/// The return value is whether or not the item was dropped. This can be used to drop additional items if certain ones were dropped (e.g. Stynger causing Stynger Bolts to also drop).
		/// <param name="npc">The entity from which to drop an item.</param>
		/// <param name="itemID">The item to be dropped.</param>
		/// <param name="amount">The amount of the item to drop.</param>
		/// <param name="modifiers">Whether or not the item should have modifiers.</param>
		/// <param name="num">Combines with den to make a fractional (<100%) drop chance; this number is the numerator.</param>
		/// <param name="den">Combines with num to make a fractional (<100%) drop chance; this number is the denominator.</param>
		/// </summary>
		private bool RunItemDrop(NPC npc, int itemID, int amount = 1, bool modifiers = false, int num = 1, int den = 1)
		{
			if (Main.netMode == 1)
				return false;

			if (Main.rand.Next(den) < num)
			{
				Item.NewItem(npc.Hitbox, itemID, amount, false, modifiers ? -1 : 0, false, false);
				return true;
			}
			return false;
		}

		/// <summary>
		/// The same as RunItemDrop, but any further drops for the item will be prevented.
		/// Good for overwriting or reworking loot tables.
		/// </summary>
		/// <param name="npc">The entity from which to drop an item.</param>
		/// <param name="itemID">The item to be dropped.</param>
		/// <param name="amount">The amount of the item to drop.</param>
		/// <param name="modifiers">Whether or not the item should have modifiers.</param>
		/// <param name="num">Combines with den to make a fractional (<100%) drop chance; this number is the numerator.</param>
		/// <param name="den">Combines with num to make a fractional (<100%) drop chance; this number is the denominator.</param>
		/// <returns>Whether the item was dropped or not.</returns>
		private bool RunItemDropOnce(NPC npc, int itemID, int amount = 1, bool modifiers = false, int num = 1, int den = 1)
		{
			bool result = RunItemDrop(npc, itemID, amount, modifiers, num, den);
			NPCLoader.blockLoot.Add(itemID);
			return result;
		}

		private bool RunItemDropWhen(NPC npc, bool condition, int itemID, int amount = 1, bool modifiers = false, int num = 1, int den = 1)
		{
			bool result = false;

			if (condition)
				result = RunItemDropOnce(npc, itemID, amount, modifiers, num, den);
			else
				NPCLoader.blockLoot.Add(itemID);

			return result;
		}

		public override void SpawnNPC(int npc, int tileX, int tileY)
		{
			if (Main.npc[npc].type == NPCType<TheGrandThunderBirdv2>() && Main.npc[npc].boss)
			{
				Main.npc[npc].ai[3] = 2f;
				Main.npc[npc].ai[2] = 60f;
				Main.npc[npc].netUpdate = true;
			}
		}

		private void Shoot(NPC npc, int delay, float distance, int speed, int proj, int dmg, float kb, bool recolor = false, bool hostile = false)
		{
			int t = npc.HasPlayerTarget ? npc.target : npc.FindClosestPlayer();
			if (t == -1)
				return;

			Player player = Main.player[t];
			//npc facing player target or if already started attack
			if (player.active && !player.dead && npc.direction == (Math.Sign(player.position.X - npc.position.X)) || Stop > 0)
			{
				//start the pause
				if (delay != 0 && Stop == 0)
				{
					Stop = delay;
				}
				//half way through start attack
				else if (delay == 0 || Stop == delay / 2)
				{
					Vector2 velocity = Vector2.Normalize(player.Center - npc.Center) * speed;
					if (npc.Distance(player.Center) < distance)
						velocity = Vector2.Normalize(player.Center - npc.Center) * speed;
					else //player too far away now, just shoot straight ahead
						velocity = new Vector2(npc.direction * speed, 0);

					int p = Projectile.NewProjectile(npc.Center, velocity, proj, dmg, kb, Main.myPlayer);
					if (p < 1000)
					{
						if (recolor)
							Main.projectile[p].GetGlobalProjectile<FargowiltasSouls.Projectiles.FargoGlobalProjectile>().IsRecolor = true;
						if (hostile)
						{
							Main.projectile[p].friendly = false;
							Main.projectile[p].hostile = true;
						}
					}
					Counter = 0;
				}
			}
		}

		private void Aura(NPC npc, float distance, int buff, bool reverse = false, int dustid = DustID.GoldFlame, bool checkDuration = false)
		{
			//works because buffs are client side anyway :ech:
			Player p = Main.player[Main.myPlayer];
			float range = npc.Distance(p.Center);
			if (reverse ? range > distance && range < 3000f : range < distance)
				p.AddBuff(buff, checkDuration && Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);

			for (int i = 0; i < 20; i++)
			{
				Vector2 offset = new Vector2();
				double angle = Main.rand.NextDouble() * 2d * Math.PI;
				offset.X += (float)(Math.Sin(angle) * distance);
				offset.Y += (float)(Math.Cos(angle) * distance);
				Dust dust = Main.dust[Dust.NewDust(
					npc.Center + offset - new Vector2(4, 4), 0, 0,
					dustid, 0, 0, 100, Color.White, 1f
					)];
				dust.velocity = npc.velocity;
				if (Main.rand.Next(3) == 0)
					dust.velocity += Vector2.Normalize(offset) * (reverse ? 5f : -5f);
				dust.noGravity = true;
			}
		}

		public static bool BossIsAlive(ref int bossID, int bossType)
		{
			if (bossID != -1)
			{
				if (Main.npc[bossID].active && Main.npc[bossID].type == bossType)
				{
					return true;
				}
				else
				{
					bossID = -1;
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		private bool ThoriumNPC(NPC npc)
		{
			if (npc.modNPC != null)
			{
				if (npc.modNPC.mod.Name == "ThoriumMod")
				{
					return true;
				}
			}
			return false;
		}
	}
}