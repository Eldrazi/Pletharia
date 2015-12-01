using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Dusts.Staves
{
    public class DiamondDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.frame.X = Main.rand.Next(2) * 8;
            dust.frame.Y = Main.rand.Next(2) * 8;
            dust.noLight = true;
        }
    }
}
