using Microsoft.Xna.Framework;
using Terraria;

namespace ClickerClass.Projectiles
{
    public class HemoClickerPro : ClickerProjectile
    {
        public override void SetDefaults()
        {
            isClickerProj = true;
            projectile.width = 8;
            projectile.height = 8;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.alpha = 255;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[projectile.owner];
            damage = damage + (target.defense / 2);
            hitDirection = target.Center.X < player.Center.X ? -1 : 1;
        }

        public override void AI()
        {
            if (projectile.timeLeft < 280)
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
                float num364 = projectile.velocity.X / 3f * num363;
                float num365 = projectile.velocity.Y / 3f * num363;
                int num366 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 183, 0f, 0f, 75, default, 1.35f);
                Main.dust[num366].position.X = projectile.Center.X - num364;
                Main.dust[num366].position.Y = projectile.Center.Y - num365;
                Main.dust[num366].velocity *= 0f;
                Main.dust[num366].noGravity = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
    }
}