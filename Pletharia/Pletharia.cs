using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia
{
    public class Pletharia : Mod
    {
        public override void SetModInfo(out string name, ref ModProperties properties)
        {
            name = "Pletharia";
            properties.Autoload = true;
            properties.AutoloadGores = true;
            properties.AutoloadSounds = true;
        }
    }
}
