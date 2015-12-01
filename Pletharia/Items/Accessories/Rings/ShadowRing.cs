using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories.Rings
{
    public class ShadowRing : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Shadow Ring";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants defence against darkness";
            item.value = Item.buyPrice(0, 1, 60, 0);
            item.rare = 4;

            item.defense = 3;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Blackout] = true;

            Lighting.AddLight(player.position, 0.5F, 0, 0.5F); // Add a small, red light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.RottenChunk, 10);
            recipe.AddIngredient(ItemID.ShadowScale, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddIngredient(null, "PowerlessRing");
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Vertebrae, 10);
            recipe.AddIngredient(ItemID.TissueSample, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
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
