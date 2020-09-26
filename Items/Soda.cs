using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ClickerClass.Items
{
    public class Soda : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Reduces the amount of clicks required for a click effect by 1");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 25000;
            item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ClickerPlayer>().clickerBonus += 1;
        }
    }
}