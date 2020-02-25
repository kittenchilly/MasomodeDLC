using FargowiltasSouls;
using FargowiltasSouls.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
using ThoriumMod.Projectiles;
using ThoriumMod.Projectiles.Boss;
using ThoriumMod.Projectiles.Enemy;
using static Terraria.ModLoader.ModContent;

namespace MasomodeDLC.Thorium
{
    public class ThoriumGlobalProj : GlobalProjectile
    {
        private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
        private readonly Mod FargoSouls = ModLoader.GetMod("FargowiltasSouls");
        public int CachedDamage;
        public bool firstTick = false;

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override bool PreAI(Projectile proj)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
                if (ThoriumProj(proj))
                {
                    if (!firstTick)
                    {
                        if
                        (
                        proj.type == ProjectileType<GrandThunderBirdZap>()
                        )
                        {
                            proj.tileCollide = false;
                            firstTick = true;
                        }
                    }
                }
            }
            return true;
        }

        public override void PostAI(Projectile proj)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
                if (ThoriumProj(proj))
                {
                    if (proj.damage != CachedDamage)
                    {
                        if
                        (
                        proj.type == ProjectileType<GrandThunderBirdZap>() ||
                        proj.type == ProjectileType<ThunderGust>()
                        )
                        {
                            if (FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.birdBoss, NPCType<TheGrandThunderBirdv2>()))
                                proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.ThunderBirdCount * .0125));
                        }
                        else if
                        (
                        proj.type == ProjectileType<BubbleBomb>() ||
                        proj.type == ProjectileType<BubblePulse>() ||
                        proj.type == ProjectileType<QueenTorrent>()
                        )
                        {
                            if (FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.jellyfishBoss, NPCType<QueenJelly>()))
                                proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.JellyCount * .0125));
                        }
                        else if
                        (
                        proj.type == ProjectileType<ViscountBlood>() ||
                        proj.type == ProjectileType<ViscountStomp>() ||
                        proj.type == ProjectileType<ViscountStomp2>() ||
                        proj.type == ProjectileType<ViscountRipple>() ||
                        proj.type == ProjectileType<ViscountRipple2>() ||
                        proj.type == ProjectileType<ViscountRockFall>() ||
                        proj.type == ProjectileType<ViscountRockSummon>() ||
                        proj.type == ProjectileType<ViscountRockSummon2>()
                        )
                        {
                            if (FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.viscountBoss, NPCType<Viscount>()))
                                proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.VisCount * .0125));
                        }
                        else if
                        (
                        proj.type == ProjectileType<GraniteCharge>()
                        )
                        {
                            if (FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.graniteBoss, NPCType<GraniteEnergyStorm>()))
                                proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.GraniteCount * .0125));
                        }
                        else if
                        (
                        proj.type == ProjectileType<BuriedMagicPro2>() ||
                        proj.type == ProjectileType<BuriedShock>() ||
                        proj.type == ProjectileType<BuriedDagger>() ||
                        proj.type == ProjectileType<BuriedArrow>() ||
                        proj.type == ProjectileType<BuriedArrow2>() ||
                        proj.type == ProjectileType<BuriedArrowC>() ||
                        proj.type == ProjectileType<BuriedArrowP>() ||
                        proj.type == ProjectileType<BuriedArrowF>() ||
                        proj.type == ProjectileType<BuriedMagic>() ||
                        proj.type == ProjectileType<BuriedArrowFBoom>() ||
                        proj.type == ProjectileType<BuriedMagicPop>()
                        )
                        {
                            if (FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.buriedBoss, NPCType<TheBuriedWarrior>()))
                                proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.ChampionCount * .0125));
                        }
                        else if
                        (
                        proj.type == ProjectileType<BioCoreBeam>() ||
                        proj.type == ProjectileType<BioVaporize>() ||
                        proj.type == ProjectileType<CryoCoreBeam>() ||
                        proj.type == ProjectileType<CryoVaporize>() ||
                        proj.type == ProjectileType<MoltenCoreBeam>() ||
                        proj.type == ProjectileType<MoltenVaporize>() ||
                        proj.type == ProjectileType<MainBeam>() ||
                        proj.type == ProjectileType<MainBeamOuter>() ||
                        proj.type == ProjectileType<MainBeamCheese>() ||
                        proj.type == ProjectileType<VaporizeBlast>() ||
                        proj.type == ProjectileType<GravitonSurge>() ||
                        proj.type == ProjectileType<Vaporize>() ||
                        proj.type == ProjectileType<VaporizeBlast>() ||
                        proj.type == ProjectileType<GravitonCharge>() ||
                        proj.type == ProjectileType<VaporizePulse>() ||
                        proj.type == ProjectileType<VaporizeBoom>() ||
                        proj.type == ProjectileType<GravitonBoom>() ||
                        proj.type == ProjectileType<GravitySpark>()
                        )
                        {
                            if (FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.scouterBoss, NPCType<ThePrimeScouter>()))
                                proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.ScouterCount * .0125));
                        }
                        else if
                        (
                        proj.type == ProjectileType<FrostSurgeR>() ||
                        proj.type == ProjectileType<FrostSurge>() ||
                        proj.type == ProjectileType<BlizzardStart>() ||
                        proj.type == ProjectileType<BlizzardFang>() ||
                        proj.type == ProjectileType<IceAnomaly>() ||
                        proj.type == ProjectileType<FrostMytePro>() ||
                        proj.type == ProjectileType<BlizzardCascade>() ||
                        proj.type == ProjectileType<BlizzardBoom>()
                        )
                        {
                            if (FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.striderBoss, NPCType<BoreanStrider>()) || FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.striderBoss, NPCType<BoreanStriderPopped>()))
                                proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.StriderCount * .0125));
                        }
                        else if
                        (
                        proj.type == ProjectileType<BeholderBeam>() ||
                        proj.type == ProjectileType<DoomBeholderBeam>() ||
                        proj.type == ProjectileType<VoidLaserPro>() ||
                        proj.type == ProjectileType<BeholderLavaCascade>()
                        )
                        {
                            if (FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.coznixBoss, NPCType<FallenDeathBeholder>()) || FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.coznixBoss, NPCType<FallenDeathBeholder2>()))
                                proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.BeholderCount * .0125));
                        }
                        else if
                        (
                        proj.type == ProjectileType<LichGazeB>() ||
                        proj.type == ProjectileType<LichGaze>() ||
                        proj.type == ProjectileType<LichFlareSpawn>() ||
                        proj.type == ProjectileType<LichPulse>() ||
                        proj.type == ProjectileType<SoulRenderLich>() ||
                        proj.type == ProjectileType<SoulSiphon>() ||
                        proj.type == ProjectileType<LichFlareDeathD>() ||
                        proj.type == ProjectileType<LichFlareDeathU>() ||
                        proj.type == ProjectileType<LichFlare>() ||
                        proj.type == ProjectileType<LichSing>() ||
                        proj.type == ProjectileType<LichMatter>()
                        )
                        {
                            if (FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.lichBoss, NPCType<Lich>()) || FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.lichBoss, NPCType<LichHeadless>()))
                                proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.LichCount * .0125));
                        }
                        else if
                        (
                        proj.type == ProjectileType<Whirlpool>() ||
                        proj.type == ProjectileType<AbyssionSpit>() ||
                        proj.type == ProjectileType<AbyssionSpit2>() ||
                        proj.type == ProjectileType<AquaRipple>() ||
                        proj.type == ProjectileType<AbyssalStrike>() ||
                        proj.type == ProjectileType<AbyssalStrike2>() ||
                        proj.type == ProjectileType<OldGodSpit>() ||
                        proj.type == ProjectileType<OldGodSpit2>()
                        )
                        {
                            if (FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.abyssBoss, NPCType<Abyssion>()) || FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.abyssBoss, NPCType<AbyssionCracked>()) || FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.abyssBoss, NPCType<AbyssionReleased>()))
                                proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.AbyssionCount * .0125));
                        }
                        else if
                        (
                        proj.type == ProjectileType<FlameLash>() ||
                        proj.type == ProjectileType<WaterPulse>() ||
                        proj.type == ProjectileType<TyphoonBlastHostile>() ||
                        proj.type == ProjectileType<TyphoonBlastHostileSmaller>() ||
                        proj.type == ProjectileType<AquaBarrage>() ||
                        proj.type == ProjectileType<AquaBlast>() ||
                        proj.type == ProjectileType<UFOBlast>() ||
                        proj.type == ProjectileType<OmniSphereOrb>() ||
                        proj.type == ProjectileType<DeathRaySpawn>() ||
                        proj.type == ProjectileType<RealityDreadPro>() ||
                        proj.type == ProjectileType<DeathRaySpawnR>() ||
                        proj.type == ProjectileType<DeathRaySpawnL>() ||
                        proj.type == ProjectileType<OmniDeath>() ||
                        proj.type == ProjectileType<RealityFury>() ||
                        proj.type == ProjectileType<FlamePulsePro>() ||
                        proj.type == ProjectileType<FlameNova>() ||
                        proj.type == ProjectileType<FlamePulseTorn>() ||
                        proj.type == ProjectileType<MoltenFury>() ||
                        proj.type == ProjectileType<DeathRay>() ||
                        proj.type == ProjectileType<OmniBurstHostile>() ||
                        proj.type == ProjectileType<GravitonBoom>() ||
                        proj.type == ProjectileType<FlameNovaBoom>() ||
                        proj.type == ProjectileType<SlagTornado>() ||
                        proj.type == ProjectileType<TornSlag>()
                        )
                        {
                            if
                            (
                            FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.aquaBoss, NPCType<Aquaius>()) ||
                            FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.aquaBoss, NPCType<AquaiusBubblePrime>()) ||
                            FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.aquaBoss, NPCType<Aquaius2>()) ||
                            FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.omniBoss, NPCType<Omnicide>()) ||
                            FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.slagBoss, NPCType<SlagFury>()) ||
                            FargoSoulsGlobalNPC.BossIsAlive(ref ThoriumGlobalNPC.ragBoss, NPCType<RealityBreaker>())
                            )
                            {
                                proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.RagnarokCount * .0125));
                            }
                        }
                        CachedDamage = proj.damage;
                    }
                }
            }
        }

        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
                if (ThoriumProj(projectile))
                {
                    if
                    (
                    projectile.type == ProjectileType<GrandThunderBirdZap>() ||
                    projectile.type == ProjectileType<ThunderGust>()
                    )
                    {
                        target.AddBuff(BuffID.Electrified, 300);
                    }
                }
            }
        }

        private bool ThoriumProj(Projectile projectile)
        {
            if (projectile.modProjectile != null)
            {
                if (projectile.modProjectile.mod.Name == "ThoriumMod")
                {
                    return true;
                }
            }
            return false;
        }
    }
}