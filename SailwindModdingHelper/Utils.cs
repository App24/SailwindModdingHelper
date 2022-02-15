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

        internal static void SetPlayerController(CharacterController characterController)
        {
            Utils.characterController = characterController;
            playerTransform = characterController.transform;
        }

    }
}
