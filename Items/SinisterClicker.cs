using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.Items
{
    public class SinisterClicker : ClickerItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sinister Clicker");
            Tooltip.SetDefault("Click on an enemy within range and sight to damage them");
        }

        public override void SetDefaults()
        {
            isClicker = true;
            radiusBoost = 2.2f;
            clickerColorItem = new Color(100, 25, 25, 0);
            clickerDustColor = 5;
            itemClickerAmount = 10;
            itemClickerEffect = "Siphon";
            itemClickerColorEffect = "9f0000";

            item.damage = 10;
            item.width = 30;
            item.height = 30;
            item.useTime = 1;
            item.useAnimation = 1;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.holdStyle = 3;
            item.knockBack = 2f;
            item.noMelee = true;
            item.value = 1000;
            item.rare = ItemRarityID.Blue;
            item.shoot = mod.ProjectileType("ClickDamage");
            item.shootSpeed = 1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}