using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories
{
    public class FrostyMittens : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Frosty Mittens";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants a fair amount of defence against frost";
            item.value = Item.buyPrice(0, 2, 6, 0);
            item.rare = 5;

            item.defense = 4;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.Frozen] = true;

            player.moveSpeed -= 0.1F; // Decreases move speed by 10%.

            Lighting.AddLight(player.position, 0.8F, 0.8F, 0.8F); // Add a average, red light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HandWarmer);
            recipe.AddIngredient(null, "FrostRing");
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
