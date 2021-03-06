using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CookieMod.Projectiles
{
    public class ThrowingCookieHoney : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Cookie");     //The English name of the projectile
		}
		public override void SetDefaults()
		{
			aiType = ProjectileID.WoodenArrowFriendly;
            projectile.aiStyle = 1;			
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.penetrate = 1;
			projectile.width = 16;
			projectile.height = 16;
			projectile.extraUpdates = 1;
		}
		public override void AI()
		{
            if (projectile.localAI[0] == 0f)
            {
				Main.PlaySound(SoundID.Item1, projectile.position);
                projectile.localAI[0] = 1f;
            }			
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("HoneyCrumbs"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}				           
		}
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("HoneyCrumbs"), projectile.oldVelocity.X * 0f, projectile.oldVelocity.Y * 0f);
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			return true;
		}		
	}
}
