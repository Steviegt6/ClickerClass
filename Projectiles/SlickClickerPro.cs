using Microsoft.Xna.Framework;
using Terraria;

namespace ClickerClass.Projectiles
{
    public class SlickClickerPro : ClickerProjectile
    {
        public override void SetDefaults()
        {
            isClickerProj = true;
            projectile.width = 8;
            projectile.height = 8;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
            projectile.alpha = 255;
            projectile.extraUpdates = 3;
            projectile.ignoreWater = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[projectile.owner];
            damage = (int)(damage + (target.defense / 2));
            hitDirection = target.Center.X < player.Center.X ? -1 : 1;
        }

        public override void AI()
        {
            if (projectile.timeLeft < 170)
            {
                projectile.friendly = true;
            }

            projectile.velocity.Y /= 1.0065f;

            projectile.ai[1]++;

            if (projectile.ai[1] >= 0)
            {
                projectile.velocity.Y += 1.05f;
                projectile.ai[1] = -15;
            }

            for (int num363 = 0; num363 < 3; num363++)
            {
                float num364 = projectile.velocity.X / 3f * (float)num363;
                float num365 = projectile.velocity.Y / 3f * (float)num363;
                int num366 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 33, 0f, 0f, 100, default(Color), 1.25f);
                Main.dust[num366].position.X = projectile.Center.X - num364;
                Main.dust[num366].position.Y = projectile.Center.Y - num365;
                Main.dust[num366].velocity *= 0f;
                Main.dust[num366].noGravity = true;
            }

            for (int k = 0; k < 2; k++)
            {
                int dust = Dust.NewDust(projectile.position, 10, 10, 33, Main.rand.Next((int)-1f, (int)1f), Main.rand.Next((int)-1f, (int)1f), 100, default(Color), 0.75f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}