using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories
{
    public class FossilHead : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Fossil Head";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants a fair amount of defence against the earth";
            item.value = Item.buyPrice(0, 1, 6, 0);
            item.rare = 5;

            item.defense = 4;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            player.moveSpeed -= 0.15F; // Removes 15% move speed. 
            player.jumpSpeedBoost += 1.2F; // 2 tile higher jumping.
            player.maxFallSpeed += 0.4F; // Fall 40% faster.

            Lighting.AddLight(player.position, 0.8F, 0.6F, 0); // Add a small, orange light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianSkull);
            recipe.AddIngredient(null, "ReinforcedRing");
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
