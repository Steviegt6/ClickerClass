using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.Items
{
    public class TitaniumClicker : ClickerItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titanium Clicker");
            Tooltip.SetDefault("Click on an enemy within range and sight to damage them");
        }

        public override void SetDefaults()
        {
            isClicker = true;
            radiusBoost = 3.25f;
            clickerColorItem = new Color(150, 150, 150, 0);
            clickerDustColor = 146;
            itemClickerAmount = 12;
            itemClickerEffect = "Razor's Edge";
            itemClickerColorEffect = "a2a2a2";

            item.damage = 44;
            item.width = 30;
            item.height = 30;
            item.useTime = 1;
            item.useAnimation = 1;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.holdStyle = 3;
            item.knockBack = 1f;
            item.noMelee = true;
            item.value = 1000;
            item.rare = ItemRarityID.LightRed;
            item.shoot = mod.ProjectileType("ClickDamage");
            item.shootSpeed = 1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}