using Microsoft.Xna.Framework;
using Terraria;

namespace ClickerClass.Projectiles
{
    public class DarkClickerPro : ClickerProjectile
    {
        public override void SetDefaults()
        {
            isClickerProj = true;
            projectile.width = 200;
            projectile.height = 200;
            projectile.penetrate = -1;
            projectile.timeLeft = 10;
            projectile.alpha = 255;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 3;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[projectile.owner];
            damage = damage + (target.defense / 2);
            hitDirection = target.Center.X < player.Center.X ? -1 : 1;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 15; i++)
            {
                int num6 = Dust.NewDust(target.position, target.width, target.height, 14, 0f, 0f, 75, default, 1.5f);
                Main.dust[num6].noGravity = true;
                Main.dust[num6].velocity *= 0.75f;
                int num7 = Main.rand.Next(-50, 51);
                int num8 = Main.rand.Next(-50, 51);
                Dust dust = Main.dust[num6];
                dust.position.X += num7;
                Dust dust2 = Main.dust[num6];
                dust2.position.Y += num8;
                Main.dust[num6].velocity.X = -num7 * 0.075f;
                Main.dust[num6].velocity.Y = -num8 * 0.075f;
            }
        }
    }
}