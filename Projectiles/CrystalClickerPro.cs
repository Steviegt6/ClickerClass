using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace ClickerClass.Projectiles
{
    public class CrystalClickerPro : ClickerProjectile
    {
        public override void SetDefaults()
        {
            isClickerProj = true;
            projectile.width = 8;
            projectile.height = 8;
            projectile.penetrate = -1;
            projectile.timeLeft = 10;
            projectile.alpha = 255;
            projectile.extraUpdates = 3;
        }

        public override void AI()
        {
            if (projectile.ai[0] < 1f)
            {
                for (int k = 0; k < 15; k++)
                {
                    Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 86, Main.rand.NextFloat(-8f, 8f), Main.rand.NextFloat(-8f, 8f), 0, default, 1.25f);
                    dust.noGravity = true;
                }
                for (int k = 0; k < 15; k++)
                {
                    Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 88, Main.rand.NextFloat(-8f, 8f), Main.rand.NextFloat(-8f, 8f), 0, default, 1.25f);
                    dust.noGravity = true;
                }
                for (int u = 0; u < Main.maxNPCs; u++)
                {
                    NPC target = Main.npc[u];
                    if (target.CanBeChasedBy(projectile) && target.DistanceSQ(projectile.Center) < 100 * 250)
                    {
                        target.AddBuff(BuffID.Confused, 180, false);

                        for (int i = 0; i < 8; i++)
                        {
                            int num6 = Dust.NewDust(target.position, target.width, target.height, 86, 0f, 0f, 0, default, 1f);
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
                        for (int i = 0; i < 8; i++)
                        {
                            int num6 = Dust.NewDust(target.position, target.width, target.height, 88, 0f, 0f, 0, default, 1f);
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
                projectile.ai[0] += 1f;
            }
        }
    }
}