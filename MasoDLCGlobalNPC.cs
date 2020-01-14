using FargowiltasSouls;
using FargowiltasSouls.NPCs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace MasomodeDLC
{
    public class MasoDLCGlobalNPC : GlobalNPC
    {
        private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
        private readonly Mod FargoSouls = ModLoader.GetMod("FargowiltasSouls");
        private int Stop = 0;
        public int Counter = 0;
        public int CachedDamage;

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void SetDefaults(NPC npc)
        {
            FargoSoulsGlobalNPC fargoSoulsGlobalNPC = npc.GetGlobalNPC<FargoSoulsGlobalNPC>();

            if (FargoSoulsWorld.MasochistMode)
            {
                if (Thorium != null)
                {
                    #region bosses

                    if
                    (
                    npc.type == Thorium.NPCType("ThePrimeScouter") ||
                    npc.type == Thorium.NPCType("PyroCore") ||
                    npc.type == Thorium.NPCType("BioCore") ||
                    npc.type == Thorium.NPCType("CryoCore")
                    )
                    {
                        npc.buffImmune[BuffID.Suffocation] = true;
                    }

                    #endregion bosses

                    #region everything else

                    if
                    (
                    npc.type == Thorium.NPCType("Barracuda") ||
                    npc.type == Thorium.NPCType("Blowfish") ||
                    npc.type == Thorium.NPCType("GigaClam") ||
                    npc.type == Thorium.NPCType("Globee") ||
                    npc.type == Thorium.NPCType("Hammerhead") ||
                    npc.type == Thorium.NPCType("ManofWar") ||
                    npc.type == Thorium.NPCType("MorayHead") ||
                    npc.type == Thorium.NPCType("MorayBody") ||
                    npc.type == Thorium.NPCType("MorayTail") ||
                    npc.type == Thorium.NPCType("Octopus") ||
                    npc.type == Thorium.NPCType("Sharptooth") ||
                    npc.type == Thorium.NPCType("AbyssalAngler2") ||
                    npc.type == Thorium.NPCType("AquaticHallucination") ||
                    npc.type == Thorium.NPCType("Blobfish") ||
                    npc.type == Thorium.NPCType("CrownofThorns") ||
                    npc.type == Thorium.NPCType("FeedingFrenzy") ||
                    npc.type == Thorium.NPCType("FeedingFrenzy2") ||
                    npc.type == Thorium.NPCType("Kraken") ||
                    npc.type == Thorium.NPCType("PutridSerpent") ||
                    npc.type == Thorium.NPCType("DepthMimic") ||
                    npc.type == Thorium.NPCType("Whale") ||
                    npc.type == Thorium.NPCType("VampireSquid") ||
                    npc.type == Thorium.NPCType("EelHead") ||
                    npc.type == Thorium.NPCType("EelBody") ||
                    npc.type == Thorium.NPCType("EelTail")
                    )
                    {
                        fargoSoulsGlobalNPC.isWaterEnemy = true;
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("Nestling") ||
                    npc.type == Thorium.NPCType("WindElemental") ||
                    npc.type == Thorium.NPCType("CyanHag")
                    )
                    {
                        npc.buffImmune[BuffID.Suffocation] = true;
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("GoblinSpiritGuide") ||
                    npc.type == Thorium.NPCType("ShadowflameRevenant")
                    )
                    {
                        if (!Main.hardMode)
                        {
                            npc.lifeMax /= 2;
                            npc.damage /= 2;
                        }
                    }

                    #endregion everything else
                }
            }
        }

        public override void ScaleExpertStats(NPC npc, int numPlayers, float bossLifeScale)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
                if (Thorium != null)
                {
                    if
                    (
                    npc.type == Thorium.NPCType("TheGrandThunderBirdv2") ||
                    npc.type == Thorium.NPCType("Hatchling")
                    )
                    {
                        npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.ThunderBirdCount * .025));
                        npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ThunderBirdCount * .0125));
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("QueenJelly") ||
                    npc.type == Thorium.NPCType("DistractJelly") ||
                    npc.type == Thorium.NPCType("SpittingJelly") ||
                    npc.type == Thorium.NPCType("ZealousJelly")
                    )
                    {
                        npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.JellyCount * .025));
                        npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.JellyCount * .0125));
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("Viscount") ||
                    npc.type == Thorium.NPCType("ViscountBaby")
                    )
                    {
                        npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.VisCount * .025));
                        npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.VisCount * .0125));
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("GraniteEnergyStorm") ||
                    npc.type == Thorium.NPCType("EncroachingEnergy") ||
                    npc.type == Thorium.NPCType("EnergyBarrier") ||
                    npc.type == Thorium.NPCType("EnergyCanduit") ||
                    npc.type == Thorium.NPCType("GraniteEnergy")
                    )
                    {
                        npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.GraniteCount * .025));
                        npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.GraniteCount * .0125));
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("TheBuriedWarrior") ||
                    npc.type == Thorium.NPCType("TheBuriedWarrior1") ||
                    npc.type == Thorium.NPCType("TheBuriedWarrior2") ||
                    npc.type == Thorium.NPCType("BuriedVolley")
                    )
                    {
                        npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.ChampionCount * .025));
                        npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ChampionCount * .0125));
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("ThePrimeScouter") ||
                    npc.type == Thorium.NPCType("BioCore") ||
                    npc.type == Thorium.NPCType("CryoCore") ||
                    npc.type == Thorium.NPCType("PyroCore")
                    )
                    {
                        npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.ScouterCount * .025));
                        npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ScouterCount * .0125));
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("BoreanStrider") ||
                    npc.type == Thorium.NPCType("BoreanStriderPopped") ||
                    npc.type == Thorium.NPCType("BoreanMyte1") ||
                    npc.type == Thorium.NPCType("BoreanHopper")
                    )
                    {
                        npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.StriderCount * .025));
                        npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.StriderCount * .0125));
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("FallenDeathBeholder") ||
                    npc.type == Thorium.NPCType("FallenDeathBeholder2") ||
                    npc.type == Thorium.NPCType("EnemyBeholder")
                    )
                    {
                        npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.BeholderCount * .025));
                        npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.BeholderCount * .0125));
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("Lich") ||
                    npc.type == Thorium.NPCType("LichHeadless") ||
                    npc.type == Thorium.NPCType("ThousandSoulPhalactry")
                    )
                    {
                        npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.LichCount * .025));
                        npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.LichCount * .0125));
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("Abyssion") ||
                    npc.type == Thorium.NPCType("AbyssionCracked") ||
                    npc.type == Thorium.NPCType("AbyssionReleased") ||
                    npc.type == Thorium.NPCType("AbyssalSpawn")
                    )
                    {
                        npc.lifeMax = (int)(npc.lifeMax * (1 + MasoDLCWorld.AbyssionCount * .025));
                        npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.AbyssionCount * .0125));
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("RealityBreaker") ||
                    npc.type == Thorium.NPCType("Aquaius") ||
                    npc.type == Thorium.NPCType("Aquaius2") ||
                    npc.type == Thorium.NPCType("AquaiusBubble") ||
                    npc.type == Thorium.NPCType("AquaiusBubblePrime") ||
                    npc.type == Thorium.NPCType("AquaTitan") ||
                    npc.type == Thorium.NPCType("BoundlessEntity") ||
                    npc.type == Thorium.NPCType("DeathTitan") ||
                    npc.type == Thorium.NPCType("DespairSpirit") ||
                    npc.type == Thorium.NPCType("DreadSpirit") ||
                    npc.type == Thorium.NPCType("OmegaSigil") ||
                    npc.type == Thorium.NPCType("Omnicide") ||
                    npc.type == Thorium.NPCType("RealityEaterHead") ||
                    npc.type == Thorium.NPCType("RealityEaterBody") ||
                    npc.type == Thorium.NPCType("RealityEaterTail") ||
                    npc.type == Thorium.NPCType("SlagFury") ||
                    npc.type == Thorium.NPCType("SlagTitan")
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
                if (Thorium != null)
                {
                    if (npc.type == Thorium.NPCType("TheGrandThunderBirdv2"))
                    {
                        if (npc.ai[0] < 5f)
                        {
                            if (npc.ai[3] == 0)
                            {
                                if (npc.ai[2] > 59f && npc.ai[2] < 61f)
                                {
                                    if (Main.rand.Next(2) == 0)
                                    {
                                        Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), 10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X - 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y, 8f, 0f, base.mod.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                    }
                                    else
                                    {
                                        Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y + (float)Main.rand.Next(-0xC8, 0xC8), -10f, 0f, Thorium.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                        Projectile.NewProjectile(player.Center.X + 800f + (float)Main.rand.Next(-0x1E, 0x1E), player.Center.Y, 8f, 0f, base.mod.ProjectileType("GrandThunderBirdZap"), 0xC, 3f, 0xFF, 0f, 0f);
                                    }
                                }
                            }
                            else if (npc.ai[3] == 2f)
                            {
                                if (npc.ai[2] > 59f && npc.ai[2] % 60f == 0f)
                                {
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 0xA, Thorium.NPCType("Hatchling"), 0, (float)npc.whoAmI, 0f, 0f, 0f, 0xFF);
                                }
                            }
                        }
                    }
                    if (npc.type == Thorium.NPCType("Hatchling"))
                    {
                        Counter++;
                        if (Counter >= 300)
                        {
                            Vector2 vector3 = Main.player[npc.target].Center + new Vector2(npc.Center.X, npc.Center.Y);
                            Vector2 vector4 = npc.Center + new Vector2(npc.Center.X, npc.Center.Y);
                            float num = (float)Math.Atan2((double)(vector4.Y - vector3.Y), (double)(vector4.X - vector3.X));
                            Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 0x1C, 1f, 0f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 30f, (float)(Math.Cos((double)num) * 10.0 * -1.0), (float)(Math.Sin((double)num) * 10.0 * -1.0),Thorium.ProjectileType("GrandThunderBirdZap"), 0xF, 0f, 0, 0f, 0f); Counter = 0;
                        }
                    }
                    if
                    (
                    npc.type == Thorium.NPCType("GoblinDrummer") ||
                    npc.type == Thorium.NPCType("GoblinSpiritGuide") ||
                    npc.type == Thorium.NPCType("GoblinTrapper") ||
                    npc.type == Thorium.NPCType("ShadowflameRevenant")
                    )
                    {
                        if (npc.HasPlayerTarget && (!Main.player[npc.target].active || Main.player[npc.target].dead))
                        {
                            npc.TargetClosest();
                            if (npc.HasPlayerTarget && (!Main.player[npc.target].active || Main.player[npc.target].dead))
                                npc.noTileCollide = true;
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
                if (Thorium != null)
                {
                    if (npc.damage != CachedDamage)
                    {
                        if
                        (
                        npc.type == Thorium.NPCType("TheGrandThunderBirdv2") ||
                        npc.type == Thorium.NPCType("Hatchling")
                        )
                        {
                            npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ThunderBirdCount * .0125));
                        }
                        else if
                        (
                        npc.type == Thorium.NPCType("QueenJelly") ||
                        npc.type == Thorium.NPCType("DistractJelly") ||
                        npc.type == Thorium.NPCType("SpittingJelly") ||
                        npc.type == Thorium.NPCType("ZealousJelly")
                        )
                        {
                            npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.JellyCount * .0125));
                        }
                        else if
                        (
                        npc.type == Thorium.NPCType("Viscount") ||
                        npc.type == Thorium.NPCType("ViscountBaby")
                        )
                        {
                            npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.VisCount * .0125));
                        }
                        else if
                        (
                        npc.type == Thorium.NPCType("GraniteEnergyStorm") ||
                        npc.type == Thorium.NPCType("EncroachingEnergy") ||
                        npc.type == Thorium.NPCType("EnergyBarrier") ||
                        npc.type == Thorium.NPCType("EnergyCanduit") ||
                        npc.type == Thorium.NPCType("GraniteEnergy")
                        )
                        {
                            npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.GraniteCount * .0125));
                        }
                        else if
                        (
                        npc.type == Thorium.NPCType("TheBuriedWarrior") ||
                        npc.type == Thorium.NPCType("TheBuriedWarrior1") ||
                        npc.type == Thorium.NPCType("TheBuriedWarrior2") ||
                        npc.type == Thorium.NPCType("BuriedVolley")
                        )
                        {
                            npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ChampionCount * .0125));
                        }
                        else if
                        (
                        npc.type == Thorium.NPCType("ThePrimeScouter") ||
                        npc.type == Thorium.NPCType("BioCore") ||
                        npc.type == Thorium.NPCType("CryoCore") ||
                        npc.type == Thorium.NPCType("PyroCore")
                        )
                        {
                            npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.ScouterCount * .0125));
                        }
                        else if
                        (
                        npc.type == Thorium.NPCType("BoreanStrider") ||
                        npc.type == Thorium.NPCType("BoreanStriderPopped") ||
                        npc.type == Thorium.NPCType("BoreanMyte1") ||
                        npc.type == Thorium.NPCType("BoreanHopper")
                        )
                        {
                            npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.StriderCount * .0125));
                        }
                        else if
                        (
                        npc.type == Thorium.NPCType("FallenDeathBeholder") ||
                        npc.type == Thorium.NPCType("FallenDeathBeholder2") ||
                        npc.type == Thorium.NPCType("EnemyBeholder")
                        )
                        {
                            npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.BeholderCount * .0125));
                        }
                        else if
                        (
                        npc.type == Thorium.NPCType("Lich") ||
                        npc.type == Thorium.NPCType("LichHeadless") ||
                        npc.type == Thorium.NPCType("ThousandSoulPhalactry")
                        )
                        {
                            npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.LichCount * .0125));
                        }
                        else if
                        (
                        npc.type == Thorium.NPCType("Abyssion") ||
                        npc.type == Thorium.NPCType("AbyssionCracked") ||
                        npc.type == Thorium.NPCType("AbyssionReleased") ||
                        npc.type == Thorium.NPCType("AbyssalSpawn")
                        )
                        {
                            npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.AbyssionCount * .0125));
                        }
                        else if
                        (
                        npc.type == Thorium.NPCType("RealityBreaker") ||
                        npc.type == Thorium.NPCType("Aquaius") ||
                        npc.type == Thorium.NPCType("Aquaius2") ||
                        npc.type == Thorium.NPCType("AquaiusBubble") ||
                        npc.type == Thorium.NPCType("AquaiusBubblePrime") ||
                        npc.type == Thorium.NPCType("AquaTitan") ||
                        npc.type == Thorium.NPCType("BoundlessEntity") ||
                        npc.type == Thorium.NPCType("DeathTitan") ||
                        npc.type == Thorium.NPCType("DespairSpirit") ||
                        npc.type == Thorium.NPCType("DreadSpirit") ||
                        npc.type == Thorium.NPCType("OmegaSigil") ||
                        npc.type == Thorium.NPCType("Omnicide") ||
                        npc.type == Thorium.NPCType("RealityEaterHead") ||
                        npc.type == Thorium.NPCType("RealityEaterBody") ||
                        npc.type == Thorium.NPCType("RealityEaterTail") ||
                        npc.type == Thorium.NPCType("SlagFury") ||
                        npc.type == Thorium.NPCType("SlagTitan")
                        )
                        {
                            npc.damage = (int)(npc.damage * (1 + MasoDLCWorld.RagnarokCount * .0125));
                        }
                        CachedDamage = npc.damage;
                        Main.NewText(npc.damage);
                    }
                }
            }
        }

        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
                if (Thorium != null)
                {
                    if (npc.type == Thorium.NPCType("TheGrandThunderBirdv2"))
                    {
                        if (npc.ai[2] > 300f)
                        {
                            target.AddBuff(Thorium.BuffType("Staggered"), 600);
                            Vector2 velocity = Vector2.Normalize(target.Center - npc.Center) * 30;
                            target.velocity = velocity;
                        }
                        target.AddBuff(BuffID.Electrified, 300);
                    }
                    if (npc.type == Thorium.NPCType("Biter"))
                    {
                        target.AddBuff(FargoSouls.BuffType("Rotting"), 300);
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("GoblinDrummer") ||
                    npc.type == Thorium.NPCType("GoblinSpiritGuide") ||
                    npc.type == Thorium.NPCType("GoblinTrapper") ||
                    npc.type == Thorium.NPCType("ShadowflameRevenant")
                    )
                    {
                        if (Main.hardMode)
                            target.AddBuff(FargoSouls.BuffType("LivingWasteland"), 600);
                    }
                }
            }
            Main.NewText(damage);
        }

        public override bool CheckDead(NPC npc)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
                if (Thorium != null)
                {
                    if (npc.type == Thorium.NPCType("TheGrandThunderBirdv2"))
                    {
                        if (MasoDLCWorld.ThunderBirdCount < FargoSoulsWorld.MaxCountPreHM)
                            MasoDLCWorld.ThunderBirdCount++;
                    }
                    else if (npc.type == Thorium.NPCType("QueenJelly"))
                    {
                        if (MasoDLCWorld.JellyCount < FargoSoulsWorld.MaxCountPreHM)
                            MasoDLCWorld.JellyCount++;
                    }
                    else if (npc.type == Thorium.NPCType("Viscount"))
                    {
                        if (MasoDLCWorld.VisCount < FargoSoulsWorld.MaxCountPreHM)
                            MasoDLCWorld.VisCount++;
                    }
                    else if (npc.type == Thorium.NPCType("GraniteEnergyStorm"))
                    {
                        if (MasoDLCWorld.GraniteCount < FargoSoulsWorld.MaxCountPreHM)
                            MasoDLCWorld.GraniteCount++;
                    }
                    else if (npc.type == Thorium.NPCType("TheBuriedWarrior"))
                    {
                        if (MasoDLCWorld.ChampionCount < FargoSoulsWorld.MaxCountPreHM)
                            MasoDLCWorld.ChampionCount++;
                    }
                    else if (npc.type == Thorium.NPCType("ThePrimeScouter"))
                    {
                        if (MasoDLCWorld.ScouterCount < FargoSoulsWorld.MaxCountPreHM)
                            MasoDLCWorld.ScouterCount++;
                    }
                    else if (npc.type == Thorium.NPCType("BoreanStriderPopped"))
                    {
                        if (MasoDLCWorld.StriderCount < FargoSoulsWorld.MaxCountHM)
                            MasoDLCWorld.StriderCount++;
                    }
                    else if (npc.type == Thorium.NPCType("FallenDeathBeholder2"))
                    {
                        if (MasoDLCWorld.BeholderCount < FargoSoulsWorld.MaxCountHM)
                            MasoDLCWorld.BeholderCount++;
                    }
                    else if (npc.type == Thorium.NPCType("LichHeadless"))
                    {
                        if (MasoDLCWorld.LichCount < FargoSoulsWorld.MaxCountHM)
                            MasoDLCWorld.LichCount++;
                    }
                    else if (npc.type == Thorium.NPCType("AbyssionReleased"))
                    {
                        if (MasoDLCWorld.AbyssionCount < FargoSoulsWorld.MaxCountHM)
                            MasoDLCWorld.AbyssionCount++;
                    }
                    else if (npc.type == Thorium.NPCType("RealityBreaker"))
                    {
                        if (MasoDLCWorld.RagnarokCount < FargoSoulsWorld.MaxCountHM)
                            MasoDLCWorld.RagnarokCount++;
                    }
                    else if
                    (
                    npc.type == Thorium.NPCType("GoblinDrummer") ||
                    npc.type == Thorium.NPCType("GoblinSpiritGuide") ||
                    npc.type == Thorium.NPCType("GoblinTrapper")
                    )
                    {
                        if (Main.netMode != 1)
                            Projectile.NewProjectile(npc.Center, new Vector2(Main.rand.NextFloat(-2f, 2f), -5), FargoSouls.ProjectileType("GoblinSpikyBall"), 15, 0, Main.myPlayer);
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
                            pool[Thorium.NPCType("GoblinSpiritGuide")] = ((double)spawnInfo.spawnTileY < Main.worldSurface) ? 0.1f : 0f;
                        }

                        if (surface)
                        {
                            if (ThoriumMod.ThoriumWorld.downedThunderBird)
                            {
                                if (desert)
                                {
                                    pool[Thorium.NPCType("Hatchling")] = 0.1f;
                                }
                            }
                            if (NPC.downedBoss1)
                            {
                                if (desert && rain && !sinisterIcon && !FargoSoulsGlobalNPC.AnyBossAlive())
                                {
                                    pool[Thorium.NPCType("TheGrandThunderBirdv2")] = .002f;
                                }
                            }
                        }
                    }
                }
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
    }
}