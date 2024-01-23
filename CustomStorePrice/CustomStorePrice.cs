using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace CustomStorePrice
{
    [BepInPlugin(GUID, NAME, VERSION)]
    internal class CustomStorePrice : BaseUnityPlugin
    {
        public const string GUID = "com.zhaiyiming.github.tinymins.CustomStorePrice";
        public const string NAME = "CustomStorePrice";
        public const string VERSION = "1.0.2";

        internal static ManualLogSource Log;
        internal static ConfigEntry<string> StoreItemPrices;

        private void Awake()
        {
            Log = Logger;
            StoreItemPrices = Config.Bind("Settings", "StoreItemPrices", "Boombox:30,TZP-Inhalant:30,Jetpack:300,Rocket Launcher:350", "\"Please set custom prices for store items. Each price configuration should be in the format \"name:price\", separated by commas. The value for 'name' can be selected from the following: Walkie-talkie, Flashlight, Shovel, Lockpicker, Pro-flashlight, Stun grenade, Boombox, TZP-Inhalant, Zap gun, Jetpack, Extension ladder, Radar-booster, Spray paint, Rocket Launcher, Flaregun, Emergency Flare (ammo), Toy Hammer, Remote Radar, Utility Belt, Hacking Tool, Pinger, Portable Tele, Advanced Portable Tele, Night Vision Goggles, Medkit, Peeper, Helmet, Diving Kit, Wheelbarrow, Ouija Board, Shells.");

            Harmony harmony = new Harmony(GUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
