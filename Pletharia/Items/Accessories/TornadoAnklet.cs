using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories
{
    public class TornadoAnklet : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Tornado Anklet";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants a fair amount of defence against gravity";
            item.value = Item.buyPrice(0, 2, 3, 0);
            item.rare = 5;

            item.defense = 1;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            player.moveSpeed += 0.2F; // Adds 20% move speed.
            player.accRunSpeed += 0.33F; // Adds 33% move speed acceleration.

            Lighting.AddLight(player.position, 0, 0.8F, 0.4F); // Add a small, green light to the player.
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
