using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Globals
{
    public static class GlobalFunctionality
    {
        public static void CheckItems(Mod mod, Player player, ref int damage, ref float knockBack)
        {
            // Loop throught the accessories of the player.
            for (int i = 3; i < 8 + player.extraAccessorySlots; i++)
            {
                // -50% knockback.
                if (player.armor[i].type == mod.ItemType("TornadoAnklet") || player.armor[i].type == mod.ItemType("HeavyRing"))
                    knockBack /= 2;
                else if (player.armor[i].type == mod.ItemType("ReinforcedRing"))
                    knockBack -= (knockBack / 5); // 20% less knockback
            }
        }
    }
}
