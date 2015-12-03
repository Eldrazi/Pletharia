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
            base.SetDefaults();
            this.moduleType = ModuleType.WeaponSystem;
            item.name = "Weapon Base";

            if(weaponType == WeaponType.Melee)
            {
                item.melee = true;
            }
            else if(weaponType == WeaponType.Ranged) //Weapon is ranged
            {
                item.ranged = true;
                item.noMelee = true;
            }
            weaponType = WeaponType.None;
        }
    }
}
