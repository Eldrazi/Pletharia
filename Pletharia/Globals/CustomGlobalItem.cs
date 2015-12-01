using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Globals
{
    public class CustomGlobalItem : GlobalItem
    {
        #region Vanilla Attack Functions Extended

        public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            GlobalFunctionality.CheckItems(mod, player, ref damage, ref knockBack);
        }

        #endregion
    }
}
