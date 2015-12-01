using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pletharia.Items.Weapons.Staves
{
    public class SuperSapphireStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Super Sapphire Staff";
            item.width = 40;
            item.height = 40;
            item.toolTip = "Fires a ricocheting shard of pure sapphire";
            item.value = Item.buyPrice(0, 1, 6, 0);
            item.rare = 4;

            item.noMelee = true;
            item.damage = 64;
            item.crit = 8;
            item.knockBack = 4;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            Item.staff[item.type] = true;

            item.mana = 10;
            item.magic = true;

            item.shoot = mod.ProjectileType("SapphireShard");
            item.shootSpeed = 15;
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
            recipe.AddIngredient(ItemID.SapphireStaff);
            recipe.AddIngredient(null, "AquaRing");
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
