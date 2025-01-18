using UnityEngine;
using Il2Cpp;
using MelonLoader;





namespace DroppableUndroppables
{
    internal static class DroppableUndroppablesUtils
    {

        public static bool IsScenePlayable(string scene)
        {
            return !(string.IsNullOrEmpty(scene) || scene.Contains("MainMenu") || scene == "Boot" || scene == "Empty");
        }




    }






}