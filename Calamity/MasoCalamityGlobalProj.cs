using FargowiltasSouls;
using FargowiltasSouls.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.NPCs;
using CalamityMod.Projectiles;
using CalamityMod.Projectiles.Melee;
using CalamityMod.Projectiles.Ranged;
using CalamityMod.Projectiles.Magic;
using CalamityMod.Projectiles.Summon;
using CalamityMod.Projectiles.Rogue;
using static Terraria.ModLoader.ModContent;
using MasomodeDLC.Calamity.Buffs;

namespace MasomodeDLC.Calamity
{
    public class MasoCalamityGlobalProj : GlobalProjectile
    {
        private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
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

            }
            return true;
        }

        public override void PostAI(Projectile proj)
        {
            if (FargoSoulsWorld.MasochistMode)
            {

            }
        }

		public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{

		}

		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{

		}

		public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            if (FargoSoulsWorld.MasochistMode)
            {
				if (projectile.type == ProjectileType<Spark>())
				{
					target.AddBuff(BuffID.Electrified, 120);
				}
            }
        }
    }
}