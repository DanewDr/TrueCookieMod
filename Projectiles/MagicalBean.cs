using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CookieMod.Projectiles
{
    public class MagicalBean : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magical Bean");     //The English name of the projectile
		}
		public override void SetDefaults()
		{
			aiType = ProjectileID.WoodenArrowFriendly;
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.penetrate = 1;
			projectile.width = 8;
			projectile.height = 8;
			projectile.extraUpdates = 1;
		}
        public override void AI()
        {            
			if (Main.rand.Next(8) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("PixieDust"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("PixieDust"), projectile.oldVelocity.X * 0f, projectile.oldVelocity.Y * 0f);
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
       		 {
			target.AddBuff(BuffID.Shine, 600);
      		  }
	}
}
