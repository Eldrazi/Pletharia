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
            Utility,
            Visor,
            Mobility,
            WeaponSystem
            // More to be added, but for testing purposes this should be enough.
        }
        
        public static bool isModuleRequired(ModuleBase module)
        {
            bool required;
            switch (module.moduleType)
            {
                case ModuleType.None:
                    required = false;
                    break;
                case ModuleType.Booster:
                    required = false;
                    break;
                case ModuleType.Utility:
                    required = false;
                    break;
                case ModuleType.Visor:
                    required = true;
                    break;
                case ModuleType.Mobility:
                    required = true;
                    break;
                case ModuleType.WeaponSystem:
                    required = true;
                    break;
                default:
                    required = false;
                    break;
            }
            return required;
        }

        public ModuleType moduleType;
        public float damageBoost;
        public float speedBoost;

        public float energyInput;

        public override void SetDefaults()
        {
            SetModuleData();

            AddTooltip2("Energy Input Required: " + energyInput.ToString());
            if (speedBoost != 0) AddTooltip2("Speed Boost: " + (speedBoost * 100).ToString() + "%");
            if (damageBoost != 0) AddTooltip2("Damage Boost: " + (damageBoost * 100).ToString() + "%");
        }

        /// <summary>
        /// The actual function that needs to be overriden (instead of SetDefaults) since 
        /// visuals will be handled automatically then.
        /// </summary>
        protected virtual void SetModuleData()
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
