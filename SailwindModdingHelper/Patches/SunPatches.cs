using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SailwindModdingHelper.Patches
{
    internal static class SunPatches
    {
        [HarmonyPatch(typeof(Sun), "Start")]
        public static class StartPatch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                Utils.SetPlayerController(Refs.charController);
            }
        }
    }
}
