using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Terrabot
{
    public class CoreBase : ModItem
    {
        public float energyOutput;

        public float damageBoost;
        public float speedBoost;

        /// <summary>
        /// SetCoreData is called before the rest of the info is applied.
        /// This is to implement all 'internal' data with the use of the customized data (energyOutput, etc).
        /// </summary>
        public override void SetDefaults()
        {
            SetCoreData();

            AddTooltip2("Energy Output: " + energyOutput.ToString());
            if (speedBoost != 0) AddTooltip2("Speed Boost: " + (speedBoost * 100).ToString() + "%");
            if (damageBoost != 0) AddTooltip2("Damage Boost: " + (damageBoost * 100).ToString() + "%");
        }

        /// <summary>
        /// This is the function that is to be overridden by child Core classes (instead of SetDefaults). 
        /// This makes sure that all data that should be integrated in every Core is available without calling it.
        /// </summary>
        protected virtual void SetCoreData()
        {
            item.name = "Core Base";
            item.width = 20;
            item.height = 20;
            item.toolTip = "A standard issue Cure without any energy output";
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = -1;

            energyOutput = 0;
        }
    }
}
