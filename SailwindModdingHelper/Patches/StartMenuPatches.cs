using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailwindModdingHelper.Patches
{
    internal static class StartMenuPatches
    {
        [HarmonyPatch(typeof(StartMenu), "GameToSettings")]
        public static class GameToSettingsPatch
        {
            [HarmonyPrefix]
            public static void Prefix()
            {
                Utils.GamePaused = true;
            }
        }

        [HarmonyPatch(typeof(StartMenu), "SettingsToGame")]
        public static class SettingsToGamePatch
        {
            [HarmonyPrefix]
            public static void Prefix()
            {
                Utils.GamePaused = false;
            }
        }
    }
}
