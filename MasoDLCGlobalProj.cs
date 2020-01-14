using FargowiltasSouls;
using FargowiltasSouls.NPCs;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace MasomodeDLC
{
    public class MasoDLCGlobalProj : GlobalProjectile
    {
        private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
        private readonly Mod FargoSouls = ModLoader.GetMod("FargowiltasSouls");
        public int CachedDamage;
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        

        public override void PostAI(Projectile proj)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
                if (Thorium != null)
                {
                    if (proj.damage != CachedDamage)
                    {
                        if
                        (
                        proj.type == Thorium.ProjectileType("GrandThunderBirdZap") ||
                        proj.type == Thorium.ProjectileType("ThunderGust")
                        )
                        {
                            proj.damage = (int)(proj.damage * (1 + MasoDLCWorld.ThunderBirdCount * .0125));
                        }
                        CachedDamage = proj.damage;
                        Main.NewText(proj.damage);
                    }
                }
            }
        }

        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
                if (Thorium != null)
                {
                    if
                    (
                    projectile.type == Thorium.ProjectileType("GrandThunderBirdZap")
                    )
                    {
                        target.AddBuff(BuffID.Electrified, 300);
                    }
                }
            }
        }
    }
}