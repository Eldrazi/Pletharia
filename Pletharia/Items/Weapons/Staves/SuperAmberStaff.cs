using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Weapons.Staves
{
    public class SuperAmberStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Super Amber Staff";
            item.width = 40;
            item.height = 40;
            item.toolTip = "Fires an exploding shard of pure amber";
            item.value = Item.buyPrice(0, 1, 14, 0);
            item.rare = 4;

            item.noMelee = true;
            item.damage = 80;
            item.crit = 8;
            item.knockBack = 5;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            Item.staff[item.type] = true;

            item.mana = 14;
            item.magic = true;
            item.channel = true;

            item.shoot = mod.ProjectileType("AmberShard");
            item.shootSpeed = 16;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 direction = new Vector2(speedX, speedY);
            direction.Normalize();
            position += direction * item.width;
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 1);
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EmberStaff); // Amber staff
            recipe.AddIngredient(null, "ReinforcedRing");
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
