using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Weapons.Staves
{
    public class SuperAmethystStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Super Amethyst Staff";
            item.width = 40;
            item.height = 40;
            item.toolTip = "Fires a shard of pure amethyst";
            item.value = Item.buyPrice(0, 1, 1, 40);
            item.rare = 4;

            item.noMelee = true;
            item.damage = 56;
            item.crit = 8;
            item.knockBack = 3;
            item.useTime = 30;
            item.useAnimation = 17;
            item.useStyle = 5;
            Item.staff[item.type] = true;

            item.mana = 6;
            item.magic = true;

            item.shoot = mod.ProjectileType("AmethystShard");
            item.shootSpeed = 13;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 direction = new Vector2(speedX, speedY);
            direction.Normalize();
            position += direction * item.width;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AmethystStaff); // Amber staff
            recipe.AddIngredient(null, "ShadowRing");
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
