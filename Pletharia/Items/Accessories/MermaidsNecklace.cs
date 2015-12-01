using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories
{
    public class MermaidsNecklace : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mermaid's Necklace";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants a fair amount of defence against water";
            item.value = Item.buyPrice(0, 2, 2, 25);
            item.rare = 5;

            item.defense = 2;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            if (player.wet)
            {
                player.statDefense += 3; // If the player is wet, increase defence by 3.
                player.maxRunSpeed += 0.3F; // if the player is wet, add 30% move speed.
                player.moveSpeed += 0.15F; // If the player is wet, increase move speed by 15%.
            }

            player.breathMax = (int)(player.breathMax * 1.5F); // Increase max breath by 50%.
            player.accFlipper = true; // Allow the player to swim.

            Lighting.AddLight(player.position, 0, 0.4F, 0.8F); // Add a small, blue light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JellyfishNecklace);
            recipe.AddIngredient(null, "AquaRing");
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
