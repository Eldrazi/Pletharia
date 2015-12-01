using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories.Rings
{
    public class PowerlessRing : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Powerless Ring";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Insert a gem to imbue it with magic";
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = 0;

            item.accessory = true;
        }
    }
}
