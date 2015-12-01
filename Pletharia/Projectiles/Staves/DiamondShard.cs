using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Projectiles.Staves
{
    public class DiamondShard : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Diamond Shard";
            projectile.width = 4;
            projectile.height = 4;
            projectile.friendly = true;
            projectile.light = 0.2F;
            projectile.alpha = 100;
            projectile.magic = true;
            projectile.extraUpdates = 2;
            projectile.timeLeft = 600;

            projectile.penetrate = 1;
        }

        public override bool PreAI()
        {
            if (projectile.alpha < 170)
            {
                for (int num136 = 0; num136 < 10; num136++)
                {
                    float x2 = (projectile.position.X) - projectile.velocity.X / 10f * (float)num136;
                    float y2 = (projectile.position.Y) - projectile.velocity.Y / 10f * (float)num136;
                    int num137 = Dust.NewDust(new Vector2(x2, y2), 1, 1, mod.DustType("DiamondDust"), 0f, 0f, 0, Color.White * 0.75F, 1f);
                    //Main.dust[num137].alpha = projectile.alpha;
                    Main.dust[num137].position.X = x2;
                    Main.dust[num137].position.Y = y2;
                    Main.dust[num137].velocity *= 0f;
                    Main.dust[num137].noGravity = true;
                }
            }
            float direction = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
            float ai = projectile.localAI[0];
            if (ai == 0.0F)
            {
                projectile.localAI[0] = direction;
                ai = direction;
            }

            float X = projectile.position.X;
            float Y = projectile.position.Y;
            float num5 = 300F;
            bool flag2 = false;
            int targetID = 0;
            if (projectile.ai[1] == 0.0F)
            {
                for (int i = 0; i < 200; ++i)
                {
                    if (Main.npc[i].CanBeChasedBy((object)this, false) && (projectile.ai[1] == 0.0 || projectile.ai[1] == (i + 1)))
                    {
                        float targetPosX = Main.npc[i].position.X + (Main.npc[i].width / 2);
                        float targetPosY = Main.npc[i].position.Y + (Main.npc[i].height / 2);
                        float newDir = Math.Abs(projectile.position.X + (projectile.width / 2) - targetPosX) +
                            Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - targetPosY);

                        if (newDir < num5 && Collision.CanHit(new Vector2(projectile.position.X + (projectile.width / 2),
                            projectile.position.Y + (projectile.height / 2)), 1, 1, Main.npc[i].position, Main.npc[i].width, Main.npc[i].height))
                        {
                            num5 = newDir;
                            X = targetPosX;
                            Y = targetPosY;
                            flag2 = true;
                            targetID = i;
                        }
                    }
                }
                if (flag2)
                    projectile.ai[1] = (float)(targetID + 1);
                flag2 = false;
            }
            if (projectile.ai[1] > 0.0)
            {
                int index = (int)(projectile.ai[1] - 1.0);
                if (Main.npc[index].active && Main.npc[index].CanBeChasedBy((object)this, true) && !Main.npc[index].dontTakeDamage)
                {
                    float xPos = Main.npc[index].position.X + (float)(Main.npc[index].width / 2);
                    float yPos = Main.npc[index].position.Y + (float)(Main.npc[index].height / 2);

                    float num151 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - xPos) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - yPos);
                    if (num151 < 1000f)
                    {
                        flag2 = true;
                        X = Main.npc[index].position.X + (float)(Main.npc[index].width / 2);
                        Y = Main.npc[index].position.Y + (float)(Main.npc[index].height / 2);
                    }
                }
                else
                    projectile.ai[1] = 0.0f;
            }
            if (!projectile.friendly)
                flag2 = false;

            if (flag2)
            {
                float newAI = ai;
                Vector2 vector2 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num8 = X - vector2.X;
                float num9 = Y - vector2.Y;
                float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
                float num11 = newAI / num10;
                num8 *= num11;
                num9 *= num11;
                int num14 = 8;
                projectile.velocity.X = (projectile.velocity.X * (float)(num14 - 1) + num8) / (float)num14;
                projectile.velocity.Y = (projectile.velocity.Y * (float)(num14 - 1) + num9) / (float)num14;
            }
            projectile.rotation = projectile.velocity.ToRotation() + 0.8F;
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Rectangle?(), Color.White * 0.75F, projectile.rotation, origin, projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
