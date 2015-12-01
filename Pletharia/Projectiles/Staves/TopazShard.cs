using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Projectiles.Staves
{
    public class TopazShard : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Topaz Shard";
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.light = 0.2F;
            projectile.alpha = 100;
            projectile.magic = true;

            projectile.penetrate = 1;
        }

        public override bool PreAI()
        {
            for (int num105 = 0; num105 < 1; num105++)
            {
                int num106 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("TopazDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                Main.dust[num106].noGravity = true;
                Dust dust9 = Main.dust[num106];
                dust9.velocity.X = dust9.velocity.X * 0.3f;
                dust9.velocity.Y = dust9.velocity.Y * 0.3f;
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
