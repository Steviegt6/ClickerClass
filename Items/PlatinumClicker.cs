using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.Items
{
    public class PlatinumClicker : ClickerItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Clicker");
            Tooltip.SetDefault("Click on an enemy within range and sight to damage them");
        }

        public override void SetDefaults()
        {
            isClicker = true;
            radiusBoost = 1.65f;
            clickerColorItem = new Color(125, 150, 175, 0);
            clickerDustColor = 11;
            itemClickerAmount = 8;
            itemClickerEffect = "Double Click";
            itemClickerColorEffect = "ffffff";

            item.damage = 8;
            item.width = 30;
            item.height = 30;
            item.useTime = 1;
            item.useAnimation = 1;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.holdStyle = 3;
            item.knockBack = 2f;
            item.noMelee = true;
            item.value = 1000;
            item.rare = ItemRarityID.White;
            item.shoot = mod.ProjectileType("ClickDamage");
            item.shootSpeed = 1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBar, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}