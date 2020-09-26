using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.Items
{
    public class PointyClicker : ClickerItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pointy Clicker");
            Tooltip.SetDefault("Click on an enemy within range and sight to damage them");
        }

        public override void SetDefaults()
        {
            isClicker = true;
            radiusBoost = 2.35f;
            clickerColorItem = new Color(100, 175, 75, 0);
            clickerDustColor = 39;
            itemClickerAmount = 6;
            itemClickerEffect = "Stinging Thorn";
            itemClickerColorEffect = "65e716";

            item.damage = 13;
            item.width = 30;
            item.height = 30;
            item.useTime = 1;
            item.useAnimation = 1;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.holdStyle = 3;
            item.knockBack = 2f;
            item.noMelee = true;
            item.value = 1000;
            item.rare = ItemRarityID.Orange;
            item.shoot = mod.ProjectileType("ClickDamage");
            item.shootSpeed = 1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores, 8);
            recipe.AddIngredient(ItemID.Stinger, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}