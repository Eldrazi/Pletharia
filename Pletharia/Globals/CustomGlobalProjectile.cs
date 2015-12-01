using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Globals
{
    public class CustomGlobalProjectile : GlobalProjectile
    {
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            GlobalFunctionality.CheckItems(mod, Main.player[projectile.owner], ref damage, ref knockBack);
        }
    }
}
