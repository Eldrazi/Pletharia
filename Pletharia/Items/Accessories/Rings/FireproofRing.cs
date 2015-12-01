using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Accessories.Rings
{
    public class FireproofRing : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Fireproof Ring";
            item.width = 20;
            item.height = 20;
            item.toolTip = "Grants defence against fire";
            item.value = Item.buyPrice(0, 1, 4, 50);
            item.rare = 4;

            item.defense = 2;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            // If the player has either of the buffs, add 1 defence.
            if (player.HasBuff(BuffID.OnFire) >= 0 || player.HasBuff(BuffID.CursedInferno) >= 0)
                player.statDefense += 1;
            player.lavaMax += 30; // Half a second lava immunity

            if (player.wet)
            {
                player.Hurt(1, 0); // If the player is in water, deal damage.
            }

            Lighting.AddLight(player.position, 0.5F, 0.1F, 0); // Add a small, red light to the player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddIngredient(ItemID.Fireblossom, 10);
            recipe.AddIngredient(ItemID.Hellstone, 10);
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
