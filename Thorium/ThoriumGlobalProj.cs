using FargowiltasSouls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Projectiles.Boss;
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
                            proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.ThunderBirdCount * .0125));
                        }
                        else if
                        (
                        proj.type == ProjectileType<BubbleBomb>() ||
                        proj.type == ProjectileType<BubblePulse>() ||
                        proj.type == ProjectileType<QueenTorrent>()
                        )
                        {
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
                            proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.VisCount * .0125));
                        }
                        //else if
                        //(
                        //proj.type == ProjectileType<GraniteCharge>() ||

                        //)
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