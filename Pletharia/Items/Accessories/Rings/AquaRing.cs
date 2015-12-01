using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories.Rings
{
    public class AquaRing : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Aqua Ring";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants defence against water";
            item.value = Item.buyPrice(0, 1, 2, 25);
            item.rare = 4;

            item.defense = 2;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            if (player.wet)
            {
                player.statDefense += 2; // If the player is wet, increase defence by 2.
                player.maxRunSpeed += 0.2F; // if the player is wet, add 20% move speed.
            }

            player.breathMax = (int)(player.breathMax * 1.25F); // Increase max breath by 25%.
            player.accFlipper = true; // Allow the player to swim.

            Lighting.AddLight(player.position, 0, 0.1F, 0.5F); // Add a small, blue light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Bass, 10);
            recipe.AddIngredient(ItemID.Waterleaf, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(null, "PowerlessRing");
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
