using System;
using System.Collections.Generic;
using System.Reflection;
using FargowiltasSouls;
using FargowiltasSouls.Buffs.Masomode;
using FargowiltasSouls.NPCs;
using MasomodeDLC.Calamity.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MasomodeDLC.Calamity
{
	public class MasoCalamityGlobalNPC : GlobalNPC
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        private static readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
        private static readonly Mod FargoSouls = ModLoader.GetMod("FargowiltasSouls");
        public bool[] masoBool = new bool[4];
        public float[] masoFloat = new float[4];
        public int Stop = 0;
        public int Counter = 0;
        public int Counter2 = 0;
        public int CachedDamage;
        public int lastPlayerAttack;

        public override bool InstancePerEntity => true;

        public static int boss = -1;

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


            bool nearLava = Collision.LavaCollision(spawnInfo.player.position, spawnInfo.spawnTileX, spawnInfo.spawnTileY);
            bool noInvasion = MasomodeDLC.NoInvasion(spawnInfo);
            bool normalSpawn = !spawnInfo.playerInTown && noInvasion && !oldOnesArmy;

            bool sinisterIcon = spawnInfo.player.GetModPlayer<FargoPlayer>().SinisterIcon;

			if (FargoSoulsWorld.MasochistMode)
			{
				if (night && surface)
				{
					pool[ClamNPCIDs.BlightedEye] = (ClamWorldBools.DownedCuteAnimeHiveMind || ClamWorldBools.DownedPerfs) ? 0.0215f : 0f;
					pool[ClamNPCIDs.CalamityEye] = ClamWorldBools.DownedBootlegCalamitas ? 0.185f : 0f;
				}
				if (desert)
				{
					pool[ClamNPCIDs.DriedSeekerHead] = ClamWorldBools.DownedDessertWorm ? 0.037f : 0.0145f;
				}
				ModPlayer calPlayer = spawnInfo.player.GetModPlayer(Calamity, "CalamityPlayer");
				FieldInfo field = calPlayer.GetType().GetField("ZoneCalamity");
				var zoneCalamity = field.GetValue(calPlayer); // for getting the value of the field
				if (underworld && !(bool)zoneCalamity)
				{
					pool[ClamNPCIDs.CalamityEye] = ClamWorldBools.DownedBootlegCalamitas ? 0.154f : 0f;
				}
			}
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            float spawnRates = spawnRate;
            float maxSpawnsReal = maxSpawns;
            if (player.HasBuff(BuffType<ForcedPeace>()))
            {
                spawnRates /= .78f;
                maxSpawnsReal *= 0.78f;
            }
            if (player.HasBuff(BuffType<ForcedZen>()))
            {
                spawnRates /= .42f;
                maxSpawnsReal *= 0.42f;
            }
            spawnRate = (int)spawnRates;
            maxSpawns = (int)maxSpawnsReal;
            base.EditSpawnRate(player, ref spawnRate, ref maxSpawns);
        }

        public override void SetDefaults(NPC npc)
        {
            FargoSoulsGlobalNPC fargoSoulsGlobalNPC = npc.GetGlobalNPC<FargoSoulsGlobalNPC>();
            if (FargoSoulsWorld.MasochistMode)
            {
				if (Calamity != null)
                {
                    if (npc.type == ClamNPCIDs.StormlionCharger)
                    {
                        npc.lifeMax = 250;
                        npc.buffImmune[BuffID.Electrified] = true;
                        npc.buffImmune[BuffType<LightningRod>()] = true;
                    }
                    if (npc.type == ClamNPCIDs.GhostBell)
                    {
                        npc.buffImmune[BuffID.Electrified] = true;
                        if (Main.hardMode)
                            npc.buffImmune[BuffType<LightningRod>()] = true;
                    }
                }
            }
        }

        public override void ScaleExpertStats(NPC npc, int numPlayers, float bossLifeScale)
        {
			if (FargoSoulsWorld.MasochistMode)
			{
				#region Boss Scaling
				if (npc.type == ClamNPCIDs.SandScourgeHead ||
					npc.type == ClamNPCIDs.SandScourgeBody ||
					npc.type == ClamNPCIDs.SandScourgeTail ||
					npc.type == ClamNPCIDs.SandScourgeHeadSmall ||
					npc.type == ClamNPCIDs.SandScourgeBodySmall ||
					npc.type == ClamNPCIDs.SandScourgeTailSmall)
				{
					npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.DesertWormBossCount * .025));
					npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.DesertWormBossCount * .0125));
				}

				if ((npc.type == ClamNPCIDs.DriedSeekerHead ||
					npc.type == ClamNPCIDs.DriedSeekerBody ||
					npc.type == ClamNPCIDs.DriedSeekerTail) && NPC.AnyNPCs(ClamNPCIDs.SandScourgeHead))
				{
					npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.DesertWormBossCount * .025));
					npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.DesertWormBossCount * .025));
				}

				if (npc.type == ClamNPCIDs.Crabulon ||
					npc.type == ClamNPCIDs.CrabulonShroom)
				{
					npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.CrabRaveCount * .025));
					npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.CrabRaveCount * .0125));
				}

				if (npc.type == ClamNPCIDs.HiiHMiiM ||
					npc.type == ClamNPCIDs.HiiHMiiM2 ||
					npc.type == ClamNPCIDs.HiveBlob ||
					npc.type == ClamNPCIDs.HiveBlob2 ||
					npc.type == ClamNPCIDs.DankCreeperAwMan ||
					npc.type == ClamNPCIDs.DarkHeart)
				{
					npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.HiiHMiiMCount * .025));
					npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.HiiHMiiMCount * .0125));
				}

				if ((npc.type == NPCID.EaterofSouls ||
					 npc.type == NPCID.DevourerHead ||
					 npc.type == NPCID.DevourerBody ||
					 npc.type == NPCID.DevourerTail) && (NPC.AnyNPCs(ClamNPCIDs.HiiHMiiM) || NPC.AnyNPCs(ClamNPCIDs.HiiHMiiM2)))
				{
					npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.HiiHMiiMCount * .025));
					npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.HiiHMiiMCount * .0125));
				}
				if (npc.type == ClamNPCIDs.PerfHive ||
					npc.type == ClamNPCIDs.PerfWormHeadSmall ||
					npc.type == ClamNPCIDs.PerfWormBodySmall ||
					npc.type == ClamNPCIDs.PerfWormTailSmall ||
					npc.type == ClamNPCIDs.PerfWormHeadMedium ||
					npc.type == ClamNPCIDs.PerfWormBodyMedium ||
					npc.type == ClamNPCIDs.PerfWormTailMedium ||
					npc.type == ClamNPCIDs.PerfWormHeadBig ||
					npc.type == ClamNPCIDs.PerfWormBodyBig ||
					npc.type == ClamNPCIDs.PerfWormTailBig)
				{
					npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.BloodyWormBossesCount * .025));
					npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.BloodyWormBossesCount * .0125));
				}

				if (npc.type == ClamNPCIDs.SlimeGodCore ||
					npc.type == ClamNPCIDs.SlimeGodWhichOneIsWhich ||
					npc.type == ClamNPCIDs.SlimeGodWhichOneIsWhichSplit ||
					npc.type == ClamNPCIDs.SlimeGodWhichOtherOneIsWhich ||
					npc.type == ClamNPCIDs.SlimeGodWhichOtherOneIsWhichSplit ||
					npc.type == ClamNPCIDs.SlimeGodSpawnCorrupt ||
					npc.type == ClamNPCIDs.SlimeGodSpawnCrimson ||
					npc.type == ClamNPCIDs.SlimeGodSpawnCrimson2)
				{
					npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.TwoBiomeMimicsAndAFlockoCount * .025));
					npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.TwoBiomeMimicsAndAFlockoCount * .0125));
				}
				npc.GetGlobalNPC<MasoCalamityGlobalNPC>().CachedDamage = npc.damage;
				#endregion
			}
        }

        public override bool PreAI(NPC npc)
        {
            Player player = Main.player[npc.target];
			if (FargoSoulsWorld.MasochistMode)
			{
			}
            return true;
        }

        public override void PostAI(NPC npc)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
				if (Calamity != null)
				{
					if (npc.damage != CachedDamage)
					{
						if (npc.type == ClamNPCIDs.SandScourgeHead ||
							npc.type == ClamNPCIDs.SandScourgeBody ||
							npc.type == ClamNPCIDs.SandScourgeTail ||
							npc.type == ClamNPCIDs.SandScourgeHeadSmall ||
							npc.type == ClamNPCIDs.SandScourgeBodySmall ||
							npc.type == ClamNPCIDs.SandScourgeTailSmall)
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.DesertWormBossCount * .0125));
						}

						if (npc.type == ClamNPCIDs.Crabulon ||
							npc.type == ClamNPCIDs.CrabulonShroom)
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.CrabRaveCount * .0125));
						}

						if (npc.type == ClamNPCIDs.HiiHMiiM ||
							npc.type == ClamNPCIDs.HiiHMiiM2 ||
							npc.type == ClamNPCIDs.DankCreeperAwMan ||
							npc.type == ClamNPCIDs.HiveBlob ||
							npc.type == ClamNPCIDs.HiveBlob2 ||
							npc.type == ClamNPCIDs.DarkHeart)
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.HiiHMiiMCount * .0125));
						}

						if ((npc.type == NPCID.EaterofSouls ||
							 npc.type == NPCID.DevourerHead ||
							 npc.type == NPCID.DevourerBody ||
							 npc.type == NPCID.DevourerTail) && (NPC.AnyNPCs(ClamNPCIDs.HiiHMiiM) || NPC.AnyNPCs(ClamNPCIDs.HiiHMiiM2)))
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.HiiHMiiMCount * .0125));
						}

						if (npc.type == ClamNPCIDs.PerfHive ||
							npc.type == ClamNPCIDs.PerfWormHeadBig ||
							npc.type == ClamNPCIDs.PerfWormHeadMedium ||
							npc.type == ClamNPCIDs.PerfWormHeadSmall)
						{
							npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.BloodyWormBossesCount * .0125));
						}

						CachedDamage = npc.damage;
					}

					if (npc.type == ClamNPCIDs.StormlionCharger)
					{
						npc.GetGlobalNPC<MasoCalamityGlobalNPC>().masoFloat[0] += 1;
						if (npc.GetGlobalNPC<MasoCalamityGlobalNPC>().masoFloat[0] >= 22)
						{
							npc.GetGlobalNPC<MasoCalamityGlobalNPC>().masoFloat[0] = 0;
							Projectile projectile = Projectile.NewProjectileDirect(npc.Center, new Vector2(0, 8).RotatedByRandom(30f), ClamProjectileIDs.AmidiasSpark, 35, 0f, Main.myPlayer, 0, 0);
							projectile.melee = false;
							projectile.friendly = false;
							projectile.hostile = true;
						}
					}

					if (npc.type == ClamNPCIDs.GhostBell)
					{
						npc.GetGlobalNPC<MasoCalamityGlobalNPC>().masoFloat[0] += 1;
						if (npc.GetGlobalNPC<MasoCalamityGlobalNPC>().masoFloat[0] >= 400)
						{
							Aura(npc, 180, BuffID.Electrified, false, DustID.Electric);
							npc.dontTakeDamage = true;
						}
						else
						{
							npc.dontTakeDamage = false;
						}
						if (npc.GetGlobalNPC<MasoCalamityGlobalNPC>().masoFloat[0] >= 600)
						{
							npc.GetGlobalNPC<MasoCalamityGlobalNPC>().masoFloat[0] = 0;
						}
					}
				}
            }
        }

        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            npc.GetGlobalNPC<MasoCalamityGlobalNPC>().lastPlayerAttack = player.whoAmI;
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            npc.GetGlobalNPC<MasoCalamityGlobalNPC>().lastPlayerAttack = projectile.owner;
        }

        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
                if (Calamity != null)
                {
                    if (npc.type == ClamNPCIDs.StormlionCharger)
                    {
                        target.AddBuff(BuffType<LightningRod>(), 150);
                    }
                }
            }
        }

        public override bool CheckDead(NPC npc)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
                if (Calamity != null)
                {
                    if (npc.type == ClamNPCIDs.SandScourgeHead && MasoDLCWorld.DesertWormBossCount < MasoDLCWorld.clamMaxCountPreHM)
                    {
                        MasoDLCWorld.DesertWormBossCount++;
                    }

                    if (npc.type == ClamNPCIDs.Crabulon && MasoDLCWorld.CrabRaveCount < MasoDLCWorld.clamMaxCountPreHM)
                    {
                        MasoDLCWorld.CrabRaveCount++;
                    }

                    if (npc.type == ClamNPCIDs.HiiHMiiM2 && MasoDLCWorld.HiiHMiiMCount < MasoDLCWorld.clamMaxCountPreHM)
                    {
                        MasoDLCWorld.HiiHMiiMCount++;
                    }

                    if (npc.type == ClamNPCIDs.PerfHive && MasoDLCWorld.BloodyWormBossesCount < MasoDLCWorld.clamMaxCountPreHM)
                    {
                        MasoDLCWorld.BloodyWormBossesCount++;
                    }

                    if (npc.type == ClamNPCIDs.SlimeGodCore && npc.boss && (!NPC.AnyNPCs(ClamNPCIDs.SlimeGodWhichOneIsWhichSplit) || !NPC.AnyNPCs(ClamNPCIDs.SlimeGodWhichOtherOneIsWhichSplit)) && MasoDLCWorld.TwoBiomeMimicsAndAFlockoCount < MasoDLCWorld.clamMaxCountPreHM)
                    {
                        MasoDLCWorld.TwoBiomeMimicsAndAFlockoCount++;
                    }

                    if (npc.type == ClamNPCIDs.SlimeGodWhichOneIsWhichSplit && npc.boss && (!NPC.AnyNPCs(ClamNPCIDs.SlimeGodCore) || NPC.CountNPCS(ClamNPCIDs.SlimeGodWhichOneIsWhichSplit) < 2 || NPC.AnyNPCs(ClamNPCIDs.SlimeGodWhichOtherOneIsWhichSplit)) && MasoDLCWorld.TwoBiomeMimicsAndAFlockoCount < MasoDLCWorld.clamMaxCountPreHM)
                    {
                        MasoDLCWorld.TwoBiomeMimicsAndAFlockoCount++;
                    }

                    if (npc.type == ClamNPCIDs.SlimeGodWhichOtherOneIsWhichSplit && npc.boss && (!NPC.AnyNPCs(ClamNPCIDs.SlimeGodCore) || !NPC.AnyNPCs(ClamNPCIDs.SlimeGodWhichOneIsWhichSplit) || NPC.CountNPCS(ClamNPCIDs.SlimeGodWhichOtherOneIsWhichSplit) < 2) && MasoDLCWorld.TwoBiomeMimicsAndAFlockoCount < MasoDLCWorld.clamMaxCountPreHM)
                    {
                        MasoDLCWorld.TwoBiomeMimicsAndAFlockoCount++;
                    }
                }
            }
            return true;
        }

		public override bool PreNPCLoot(NPC npc)
		{
			Player player = Main.player[npc.GetGlobalNPC<MasoCalamityGlobalNPC>().lastPlayerAttack];
			if (npc.type == ClamNPCIDs.CosmicElemental)
			{
				if (player.GetModPlayer<FargoPlayer>().TimsConcoction)
					RunItemDropOnce(npc, ClamItemIDs.TriumphPotion, Main.rand.Next(1, 3 + 1));
			}

			if (npc.type == ClamNPCIDs.GhostBell)
			{
				if (player.GetModPlayer<FargoPlayer>().TimsConcoction)
					RunItemDropOnce(npc, ClamItemIDs.TeslaPotion, Main.rand.Next(1, 3 + 1));
			}

			if (npc.type == ClamNPCIDs.CalamityEye)
			{
				RunItemDropWhen(npc, ClamWorldBools.DownedBootlegCalamitas && FargoSoulsWorld.MasochistMode, ClamItemIDs.CalamityAsh, 1, false, 1, 14);
				if (player.GetModPlayer<FargoPlayer>().TimsConcoction)
					RunItemDropWhen(npc, ClamWorldBools.DownedBootlegCalamitas, ClamItemIDs.CalamitasBathWater, Main.rand.Next(2, 3 + 1));
			}
			return base.PreNPCLoot(npc);
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

            for (int i = 0; i < 10; i++)
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
        private static string NoteToEveryone = "Plant is the big stupid"; // someday I will not be the only one who knows weakrefs and reflection  -Thomas
    }
}