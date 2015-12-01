using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories.Rings
{
    public class ReinforcedRing : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Reinforced Ring";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants defence against the earth";
            item.value = Item.buyPrice(0, 1, 6, 8);
            item.rare = 4;

            item.defense = 3;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            // If the player has the 'Stoned' debuff.
            if (player.HasBuff(BuffID.Stoned) >= 0)
                player.statDefense += 1;

            player.maxRunSpeed -= 0.1F; // -10% movespeed.

            Lighting.AddLight(player.position, 0.5F, 0.4F, 0); // Add a small, orange light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Amber);
            recipe.AddIngredient(ItemID.FossilOre, 10);
            recipe.AddIngredient(ItemID.IronBar, 10);
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
