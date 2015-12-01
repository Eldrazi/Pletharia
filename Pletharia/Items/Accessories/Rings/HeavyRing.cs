using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories.Rings
{
    public class HeavyRing : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Heavy Ring";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants defence against gravity";
            item.value = Item.buyPrice(0, 1, 3, 0);
            item.rare = 4;

            item.defense = 1;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            player.runAcceleration += 0.2F; // 20% faster acceleration.
            player.maxFallSpeed += 0.33F; // 33% faster fall speed.

            Lighting.AddLight(player.position, 0, 0.5F, 0.1F); // Add a small, green light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Chain, 10);
            recipe.AddIngredient(ItemID.CobaltOre, 10);
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
