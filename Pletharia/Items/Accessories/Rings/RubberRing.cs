using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories.Rings
{
    public class RubberRing : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Rubber Ring";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants defence against slowing effects";
            item.value = Item.buyPrice(0, 1, 1, 5);
            item.rare = 4;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            player.maxRunSpeed += 0.1F; // + 10% move speed.

            // If the player is running at max speed, increase defence by one.
            if (Math.Abs(player.velocity.X) >= player.maxRunSpeed)
                player.statDefense += 1;

            player.buffImmune[BuffID.Slow] = true; // Immunity to slow.

            Lighting.AddLight(player.position, 0.5F, 0.5F, 0); // Add a small, yellow light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.Rope, 10);
            recipe.AddIngredient(ItemID.Gel, 10);
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
