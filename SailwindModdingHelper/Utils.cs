using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SailwindModdingHelper
{
    public static class Utils
    {
        static CharacterController characterController;
        static Transform playerTransform;
        public static CharacterController CharacterController => characterController;
        public static Transform PlayerTransform => playerTransform;

        public static bool GamePaused { get; internal set; }

        internal static void SetPlayerController(CharacterController characterController)
        {
            Utils.characterController = characterController;
            playerTransform = characterController.transform;
        }

        public static IslandSceneryScene GetNearestIslandSceneryScene(Vector3 position)
        {
            float closestDistance = float.MaxValue;
            IslandSceneryScene closestIsland = null;
            foreach (var island in GameObject.FindObjectsOfType<IslandSceneryScene>())
            {
                float distance = Vector3.Distance(island.transform.position, position);
                if(distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIsland = island;
                }
            }
            return closestIsland;
        }

    }
}
