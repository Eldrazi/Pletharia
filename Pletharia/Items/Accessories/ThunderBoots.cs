using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories
{
    public class ThunderBoots : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Thunder Boots";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants a fair amount of defence against slowness";
            item.value = Item.buyPrice(0, 7, 1, 5);
            item.rare = 5;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            if (player.velocity.X != 0)
                player.statDefense += 2; // When the player is moving, add 2 defence.

            player.moveSpeed += 0.2F; // Adds 20% move speed. 
            player.maxRunSpeed += 3; // Adds 300% run speed.

            player.buffImmune[BuffID.Slow] = true; // Immune to slow debuff.

            Lighting.AddLight(player.position, 0.8F, 0.8F, 0); // Add a small, yellow light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LightningBoots);
            recipe.AddIngredient(null, "RubberRing");
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
