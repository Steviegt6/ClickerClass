﻿using Terraria;
using Terraria.ModLoader;

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
            item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ClickerPlayer>().clickerRadius += 0.5f;
        }
    }
}