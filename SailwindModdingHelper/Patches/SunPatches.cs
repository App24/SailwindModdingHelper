using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SailwindModdingHelper.Patches
{
    public static class SunPatches
    {
        [HarmonyPatch(typeof(Sun), "Start")]
        public static class StartPatch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                PlayerClimb component = GameObject.FindObjectOfType<PlayerClimb>();
                Utils.SetPlayerController((CharacterController)Traverse.Create(component).Field("controller").GetValue());
            }
        }
    }
}
