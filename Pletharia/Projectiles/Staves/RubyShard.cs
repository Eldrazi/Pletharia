using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Projectiles.Staves
{
    public class RubyShard : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Ruby Shard";
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.light = 0.2F;
            projectile.alpha = 100;
            projectile.magic = true;
            projectile.hide = true;

            projectile.penetrate = 3;
        }

        public override bool PreAI()
        {
            for (int num105 = 0; num105 < 1; num105++)
            {
                int num106 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("RubyDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                Main.dust[num106].noGravity = true;
                Dust dust9 = Main.dust[num106];
                dust9.velocity.X = dust9.velocity.X * 0.3f;
                dust9.velocity.Y = dust9.velocity.Y * 0.3f;
            }
            if (projectile.ai[0] == 1)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 0.8F;
                projectile.hide = false;
            }

            projectile.ai[1]++;
            if (projectile.ai[1] == 30)
                projectile.Kill();

            return false;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.ai[0] == 1)
            {
                for (int num105 = 0; num105 < 15; num105++)
                {
                    int num106 = Dust.NewDust(new Vector2(projectile.position.X - 8, projectile.position.Y - 8), projectile.width + 16, projectile.height + 16, mod.DustType("RubyDust"), projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 100, default(Color), 2f);
                    Main.dust[num106].noGravity = true;
                }

                // Spawn two additional projectiles.
                float rotInDegrees = MathHelper.ToDegrees(projectile.rotation);

                // Spawns a projectile that moves to the RIGHT of this projectile.
                float newRot = MathHelper.ToRadians(rotInDegrees + 45);
                Vector2 velocity = new Vector2((float)Math.Cos(newRot), (float)Math.Sin(newRot));
                velocity.Normalize();
                int newProj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velocity.X * 16, velocity.Y * 16, projectile.type, projectile.damage, projectile.knockBack, projectile.owner);
                Main.projectile[newProj].rotation = MathHelper.ToRadians(rotInDegrees + 90);
                Main.projectile[newProj].hide = false;

                // Spawns a projectile that moves to the LEFT of this projectile.
                newRot = MathHelper.ToRadians(rotInDegrees - 135);
                velocity = new Vector2((float)Math.Cos(newRot), (float)Math.Sin(newRot));
                velocity.Normalize();
                newProj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velocity.X * 16, velocity.Y * 16, projectile.type, projectile.damage, projectile.knockBack, projectile.owner);
                Main.projectile[newProj].rotation = MathHelper.ToRadians(rotInDegrees - 90);
                Main.projectile[newProj].hide = false;
            }
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
