using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SailwindModdingHelper
{
    public static class Prefabs
    {
        static Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();

        [HarmonyPatch(typeof(Sun), "Start")]
        private static class LoadPrefabs
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                foreach (var obj in Resources.FindObjectsOfTypeAll<GameObject>())
                {
                    List<string> parts = new List<string>(obj.name.Split(' '));
                    if (int.TryParse(parts[0], out _))
                    {
                        parts.RemoveAt(0);
                    }
                    string name = string.Join(" ", parts);
                    if (!prefabs.ContainsKey(name))
                    {
                        prefabs.Add(name, obj);
                    }
                }
            }
        }

        public static GameObject GetPrefab(string prefabName)
        {
            prefabs.TryGetValue(prefabName, out GameObject obj);
            return obj;
        }
    }
}
