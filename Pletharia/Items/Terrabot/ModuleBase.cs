using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Terrabot
{
    public class ModuleBase : ModItem
    {
        public enum ModuleType
        {
            None,
            Booster,
            UtilityWeapon
            // More to be added, but for testing purposes this should be enough.
        }
        public ModuleType moduleType;

        public float damageBoost;
        public float speedBoost;

        public float energyInput;

        public override void SetDefaults()
        {
            item.name = "Module Base";
            item.width = 20;
            item.height = 20;
            item.toolTip = "A standard issue Module without functionality";
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = -1;

            this.moduleType = ModuleType.None;            
        }
    }
}
