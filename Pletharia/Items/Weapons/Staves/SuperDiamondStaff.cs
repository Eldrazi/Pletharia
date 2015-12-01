using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Weapons.Staves
{
    public class SuperDiamondStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Super Diamond Staff";
            item.width = 40;
            item.height = 40;
            item.toolTip = "Fires a following shard of pure diamond";
            item.value = Item.buyPrice(0, 1, 1, 40);
            item.rare = 4;

            item.noMelee = true;
            item.damage = 92;
            item.crit = 8;
            item.knockBack = 5;
            item.useTime = 20;
            item.useAnimation = 17;
            item.useStyle = 5;
            Item.staff[item.type] = true;

            item.mana = 16;
            item.magic = true;

            item.shoot = mod.ProjectileType("DiamondShard");
            item.shootSpeed = 6.3F;
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
            recipe.AddIngredient(ItemID.DiamondStaff); // Amber staff
            recipe.AddIngredient(null, "FrostRing");
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
