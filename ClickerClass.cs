using Terraria.ModLoader;

namespace ClickerClass
{
    public class ClickerClass : Mod
    {
        public static ModHotKey AutoClickKey;

        public override void Load() => AutoClickKey = RegisterHotKey("Clicker Accessory", "G");

        public override void Unload() => AutoClickKey = null;
    }
}