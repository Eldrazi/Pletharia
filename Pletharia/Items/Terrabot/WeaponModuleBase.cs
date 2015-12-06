using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;


namespace Pletharia.Items.Terrabot
{
    public class WeaponModuleBase: ModuleBase
    {
        public enum WeaponType
        {
            None,
            Ranged,
            Melee
        }

        public WeaponType weaponType;
        public float baseDamage;
        
        public override void SetDefaults()
        {
            SetWeaponData();

            if(weaponType == WeaponType.Melee)
            {
                item.melee = true;
            }
            else if(weaponType == WeaponType.Ranged) // Weapon is ranged
            {
                item.ranged = true;
                item.noMelee = true;
            }
            weaponType = WeaponType.None;
        }

        /// <summary>
        /// The actual function that needs to be overriden (instead of SetDefaults) since 
        /// visuals will be handled automatically then.
        /// </summary>
        public virtual void SetWeaponData()
        {
            item.name = "Weapon Base";
            item.width = 20;
            item.height = 20;
            item.toolTip = "A standard issue Weapon without functionality";
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = -1;

            this.moduleType = ModuleType.WeaponSystem;
        }
    }
}
