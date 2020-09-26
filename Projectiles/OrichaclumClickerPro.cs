using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace ClickerClass.Projectiles
{
    public class OrichaclumClickerPro : ClickerProjectile
    {
        public int timer = 0;
        public float rotation = 0f;

        public override void SetDefaults()
        {
            isClickerProj = true;
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 240;
            projectile.extraUpdates = 3;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
            Main.projFrames[projectile.type] = 3;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[projectile.owner];
            damage = damage + (target.defense / 2);
            hitDirection = target.Center.X < player.Center.X ? -1 : 1;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 0) * (0.01f * projectile.timeLeft);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Rectangle frame = new Rectangle(0, 0, 20, 20);
            frame.Y += 20 * projectile.frame;

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(new Color(255, 255, 255, 0) * 0.25f) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, frame, color * (0.0025f * projectile.timeLeft), rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void AI()
        {
            projectile.frame = (int)projectile.ai[0];
            projectile.rotation += projectile.velocity.X > 0f ? 0.2f : -0.2f;

            timer++;
            if (timer % 5 == 0)
            {
                rotation = projectile.rotation;
            }

            if (projectile.ai[1] < 1f)
            {
                projectile.ai[1] += 1f;

                float num102 = 30f;
                int num103 = 0;
                while (num103 < num102)
                {
                    Vector2 vector12 = Vector2.UnitX * 0f;
                    vector12 += -Vector2.UnitY.RotatedBy(num103 * (6.28318548f / num102), default) * new Vector2(2f, 2f);
                    vector12 = vector12.RotatedBy(projectile.velocity.ToRotation(), default);
                    int num104 = Dust.NewDust(projectile.Center, 0, 0, 86, 0f, 0f, 0, default, 1.25f);
                    Main.dust[num104].noGravity = true;
                    Main.dust[num104].position = projectile.Center + vector12;
                    Main.dust[num104].velocity = projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 2f;
                    int num = num103;
                    num103 = num + 1;
                }
            }
        }
    }
}