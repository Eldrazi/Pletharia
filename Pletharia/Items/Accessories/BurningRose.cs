using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories
{
    public class BurningRose : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Burning Rose";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants a fair amount of defence against fire";
            item.value = Item.buyPrice(0, 3, 4, 50);
            item.rare = 5;

            item.defense = 4;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            player.lavaMax += 2; // 2 seconds lava invincibility.

            if (player.HasBuff(BuffID.CursedInferno) >= 0 || player.lavaWet)
                player.statDefense += 4;
            player.buffImmune[BuffID.OnFire] = true;
            if (player.wet)
            {
                player.Hurt(2, 0); // If the player is in water, deal damage.
            }

            Lighting.AddLight(player.position, 0.8F, 0.6F, 0); // Add a average, red light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianRose);
            recipe.AddIngredient(null, "FireproofRing");
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            // DEBUGGING, REMOVE WHEN PUBLISHING
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
