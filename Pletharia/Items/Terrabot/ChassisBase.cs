using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Terrabot
{
    public class ChassisBase : ModItem
    {
        public enum ChassisType
        {
            None = 0,
            Small = 1,
            Medium = 2,
            Large = 3
        }
        public ChassisType chassisType;

        public CoreBase core;
        public ModuleBase[] modules;

        // Return the module count that is suitable for this chassis (uses the values set in the ChassisType enum).
        protected int maxOptionalModuleCount
        {
            get { return (int)chassisType; }
        }

        // Returns the total value of the energy input of all the modules together.
        protected float totalEnergyInput
        {
            get
            {
                float r = 0;
                for (int i = 0; i < modules.Length; ++i)
                {
                    if (modules[i] != null)
                        r += modules[i].energyInput;
                }
                return r;
            }
        }
        public float totalDamageBoost
        {
            get
            {
                float returnValue = 1;

                if (core != null)
                    returnValue += core.damageBoost;
                for (int i = 0; i < modules.Length; ++i)
                {
                    if (modules[i] != null)
                        returnValue += modules[i].damageBoost;
                }

                return returnValue;
            }
        }

        public override void SetDefaults()
        {
            SetChassisData();
            modules = new ModuleBase[maxOptionalModuleCount];
        }

        /// <summary>
        /// This is the function that is to be overridden by child Chassis classes. This is to make sure that the modules array
        /// is always set (and the user can change the size of the Chassis inside the SetChassisData).
        /// </summary>
        protected virtual void SetChassisData()
        {
            item.name = "Chassis Base";
            item.width = 20;
            item.height = 20;
            item.toolTip = "A standard issue Chassis without room for any modules";
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = -1;

            this.chassisType = ChassisType.None;
        }

        public override bool CanUseItem(Player player)
        {
            if (totalEnergyInput > core.energyOutput)
                return false; // Energy input is is larger than than output, so we cannot launch the Terrabot.

            return true; // All checks passed, we are allowed to launch the Terrabot.
        }

        public override void SaveCustomData(System.IO.BinaryWriter writer)
        {
            // Save the core data.
            writer.Write(core.item.type);

            // Save all modules to file.
            for (int i = 0; i < modules.Length; ++i)
            {
                writer.Write(modules[i].item.type);
            }
        }
        public override void LoadCustomData(System.IO.BinaryReader reader)
        {
            // Load the core data.
            core = (CoreBase)ItemLoader.GetItem(reader.ReadInt32());

            // Load all modules back into the 'modules' array.
            for (int i = 0; i < modules.Length; ++i)
            {
                int value = reader.ReadInt32();
                if (ItemLoader.GetItem(value) != null)
                {
                    modules[i] = (ModuleBase)ItemLoader.GetItem(value);
                }
            }
        }
    }
}
