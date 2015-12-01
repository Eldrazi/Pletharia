using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Pletharia.Dusts.Staves
{
    public class RubyDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.frame.X = Main.rand.Next(2) * 8;
            dust.frame.Y = Main.rand.Next(2) * 8;
            dust.noLight = true;
        }
    }
}
