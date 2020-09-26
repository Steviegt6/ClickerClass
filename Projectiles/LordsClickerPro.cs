using Microsoft.Xna.Framework;
using Terraria;

namespace ClickerClass.Projectiles
{
    public class LordsClickerPro : ClickerProjectile
    {
        public override void SetDefaults()
        {
            isClickerProj = true;
            projectile.width = 196;
            projectile.height = 196;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.timeLeft = 60;
            projectile.friendly = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 7;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 60;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 0) * (0.08f * projectile.timeLeft);
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[projectile.owner];
            damage = damage + (target.defense / 2);
            damage = (int)(damage * 2.5f);
            hitDirection = target.Center.X < player.Center.X ? -1 : 1;
            crit = true;
        }

        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 12)
            {
                projectile.Kill();
                return;
            }
        }
    }
}