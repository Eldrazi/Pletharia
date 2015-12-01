using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories.Rings
{
    public class FrostRing : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Frost Ring";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants defence against frost";
            item.value = Item.buyPrice(0, 1, 6, 0);
            item.rare = 4;

            item.defense = -1;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            if (player.HasBuff(BuffID.Chilled) >= 0 || player.HasBuff(BuffID.Frostburn) >= 0 || player.HasBuff(BuffID.Frozen) >= 0)
                player.statDefense += 5;

            player.maxRunSpeed -= 0.05F; // -5% move speed.

            Lighting.AddLight(player.position, 0.5F, 0.5F, 0.5F); // Add a small, red light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddIngredient(ItemID.Shiverthorn, 10);
            recipe.AddIngredient(ItemID.IceBlock, 10);
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
