using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.Items
{
    public class ArthursClicker : ClickerItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arthur's Clicker");
            Tooltip.SetDefault("Click on an enemy within range and sight to damage them");
        }

        public override void SetDefaults()
        {
            isClicker = true;
            radiusBoost = 3.5f;
            clickerColorItem = new Color(255, 225, 0, 0);
            clickerDustColor = 87;
            itemClickerAmount = 12;
            itemClickerEffect = "Holy Nova";
            itemClickerColorEffect = "fed905";

            item.damage = 50;
            item.width = 30;
            item.height = 30;
            item.useTime = 1;
            item.useAnimation = 1;
            item.useStyle = 5;
            item.holdStyle = 3;
            item.knockBack = 1f;
            item.noMelee = true;
            item.value = 1000;
            item.rare = 5;
            item.shoot = mod.ProjectileType("ClickDamage");
            item.shootSpeed = 1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}