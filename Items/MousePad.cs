using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ClickerClass.Items
{
    public class MousePad : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases your base click radius by 25%");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 40000;
            item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ClickerPlayer>().clickerRadius += 0.5f;
        }
    }
}