using Terraria;
using Terraria.ModLoader;

namespace ClickerClass.Buffs
{
    public class Haste : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Haste");
            Description.SetDefault("Movement speed and jump speed increased");
            Main.buffNoSave[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.jumpSpeedBoost = 2f;
            player.moveSpeed += 0.2f;
            player.maxRunSpeed += 0.2f;
        }
    }
}