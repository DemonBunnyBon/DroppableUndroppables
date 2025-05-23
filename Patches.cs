﻿using MelonLoader;
using UnityEngine;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection;
using System.Collections;
using Il2CppTLD.Gear;
using Il2Cpp;
using Il2CppTLD.IntBackedUnit;

namespace DroppableUndroppables
{

    internal static class Patches
    {
       [HarmonyPatch(typeof(GearItem), "Awake")]

       public class DropPatcher
        {
            public static void Postfix(ref GearItem __instance)
            {
                if(__instance != null)
                {
                    NarrativeCollectibleItem Collectible = __instance.GetComponent<NarrativeCollectibleItem>();
                    GearItemData ItemData = __instance.m_GearItemData;

                    if (Collectible != null && Settings.instance.AllNote == true)
                    {
                        if(Settings.instance.NoteDescription == true)
                        {
                            string note = Collectible.m_NarrativeTextLocID;
                            __instance.m_DescriptionOverrideLocID = note;
                        }
                        GameManager.DestroyImmediate(__instance.GetComponent<NarrativeCollectibleItem>());

                    }
                    if (ItemData != null && (ItemData.m_CantDrop == true || __instance.m_CantDropItem == true) && Settings.instance.AllItem == true)
                    {
                        __instance.m_CantDropItem = false;
                        ItemData.m_CantDrop = false;

                    }
                    if (ItemData != null && ItemData.m_RemainInInventoryOnDrop == true && Settings.instance.AllItem == true)
                    {
                        ItemData.m_RemainInInventoryOnDrop = false;

                    }
                    if (ItemData !=null && ItemData.m_DisableMove == true && (Settings.instance.AllItem == true || Settings.instance.AllNote == true))
                    {
                        ItemData.m_DisableMove = false;
                    }
                    if(ItemData !=null && Settings.instance.AllItem == true && Settings.instance.AllNote == false)
                    {
                        if(__instance.name.Contains("GEAR_BoltCutters"))
                        {
                            GameManager.DestroyImmediate(__instance.GetComponent<NarrativeCollectibleItem>());
                            ItemData.m_DisableMove = false;
                            __instance.m_CantDropItem = false;
                            ItemData.m_CantDrop = false;
                        }
                    }
                    if (Settings.instance.ImportantWeight == true)
                    {
                        if (__instance.name.Contains("GEAR_Camera"))
                        {
                            __instance.m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(0.3f);
                        }
                        else if (__instance.name.Contains("GEAR_HandheldShortwave"))
                        {
                            __instance.m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(0.1f);
                        }
                        else if (__instance.name.Contains("GEAR_BoltCutters"))
                        {
                            __instance.m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(2f);
                        }
                        else if (__instance.name.Contains("GEAR_Respirator"))
                        {
                            __instance.m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(0.75f);
                        }


                    }
                    else if (Settings.instance.ImportantWeight == false)
                    {
                        if (__instance.name.Contains("GEAR_Camera"))
                        {
                            __instance.m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(0.0f);
                        }
                        else if (__instance.name.Contains("GEAR_HandheldShortwave"))
                        {
                            __instance.m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(0.0f);
                        }
                        else if (__instance.name.Contains("GEAR_BoltCutters"))
                        {
                            __instance.m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(0.0f);
                        }
                        else if (__instance.name.Contains("GEAR_Respirator"))
                        {
                            __instance.m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(0.0f);
                        }

                    }


                }

            }

        }


    }
}
