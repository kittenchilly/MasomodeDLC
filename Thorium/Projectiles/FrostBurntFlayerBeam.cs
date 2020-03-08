using System;
using EntropysEdge.Buffs;
using EntropysEdge.NPCs.Titania;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Buffs;

namespace MasomodeDLC.Thorium.Projectiles
{
	public class FrostBurntFlayerBeam : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Blade");
		}
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 480;
			projectile.alpha = 255;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

		public override void AI()
		{
			projectile.ai[0] += 1;
			projectile.rotation += MathHelper.ToRadians(100 * (projectile.ai[0] * projectile.ai[0]));
			if (projectile.ai[0] == 70)
			{
				float dist = 400;
				for (int i = 0; i < Main.maxPlayers; i++)
				{
					Player player = Main.player[i];
					Vector2 distanceTo = player.Center - projectile.Center;
					if (distanceTo.Length() < dist && Collision.CanHitLine(projectile.Center, projectile.width, projectile.height, player.Center, player.width, player.height))
					{
						projectile.rotation = distanceTo.ToRotation() + MathHelper.ToRadians(45f);
						dist = distanceTo.Length();
					}
				}
				for (int i = 0; i < 10; i++)
				{
					Vector2 offset = new Vector2(8, 0).RotatedByRandom(MathHelper.ToRadians(36f * i));
					Vector2 velOffset = new Vector2(3, 0).RotatedBy(offset.ToRotation());
					Dust dust = Dust.NewDustPerfect(projectile.Center + offset, DustID.Ice, velOffset, 100, default, 1f);
					dust.noGravity = true;
				}
				Main.PlaySound(SoundID.NPCHit5, projectile.Center).Pitch -= 0.10f;
			}

			if (projectile.ai[0] < 100)
			{
				Main.PlaySound(SoundID.NPCHit5, projectile.Center).Pitch += 0.15f;
			}

			if (!Main.rand.NextBool(5))
			{
				Vector2 offset = new Vector2(5, 0).RotatedByRandom(MathHelper.ToRadians(360f));
				Vector2 velOffset = new Vector2(2, 0).RotatedBy(offset.ToRotation());
				Dust dust = Dust.NewDustPerfect(projectile.Center + offset, DustID.Ice, (projectile.velocity * 0.2f) + velOffset, 100, default, 1f);
				dust.noGravity = true;
			}

			if (Main.rand.NextBool(4))
			{
				Vector2 offset = new Vector2(5, 0).RotatedByRandom(MathHelper.ToRadians(360f));
				Vector2 velOffset = new Vector2(2, 0).RotatedBy(offset.ToRotation());
				Dust dust = Dust.NewDustPerfect(projectile.Center + offset, DustID.Ice, (projectile.velocity * 0.2f) + velOffset, 100, default, 2f);
				dust.noGravity = true;
			}
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 40, false);
			target.AddBuff(ModContent.BuffType<EnemyFrozen>(), 40, false);
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Ice, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			Texture2D texture = Main.projectileTexture[projectile.type];
			Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
			Vector2 origin = sourceRectangle.Size() / 2f;

			Color drawColor = projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), sourceRectangle, drawColor, projectile.rotation, origin, 1, spriteEffects, 0f);

			return false;
		}
	}
}