using MelonLoader;
using UnityEngine;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection; 
using System.Collections;
using Il2CppTLD.Gear;
using Il2Cpp;
using Il2CppTLD.IntBackedUnit;
using Il2CppVLB;

namespace DroppableUndroppables
{
	public class DroppableUndroppablesMelon : MelonMod
	{
		public override void OnInitializeMelon()
		{
        }

		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			if(DroppableUndroppablesUtils.IsScenePlayable(sceneName))
			{
                ChangeItemProperties();
            }

			


        }

		public static void ChangeItemProperties()
		{
			GameObject gear;

			gear = GearItem.LoadGearItemPrefab("GEAR_HandheldShortwave").gameObject;

			gear.GetComponent<GearItem>().m_CantDropItem = false;
			gear.GetComponent<GearItem>().m_GearItemData.m_CantDrop = false;
			gear.GetComponent<GearItem>().m_GearItemData.m_IsPlaceable = true;
			gear.GetComponent<GearItem>().m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(0.1f);

			gear = GearItem.LoadGearItemPrefab("GEAR_BoltCutters").gameObject;

			gear.GetComponent<GearItem>().m_CantDropItem = false;
			gear.GetComponent<GearItem>().m_GearItemData.m_CantDrop = false;
			gear.GetComponent<GearItem>().m_GearItemData.m_IsPlaceable = true;
			gear.GetComponent<GearItem>().m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(2f);
			gear.GetComponent<GearItem>().m_GearItemData.m_Type = GearType.Tool;
			gear.GetComponent<GearItem>().m_IsHidden = false;
			GameManager.DestroyImmediate(gear.GetComponent<NarrativeCollectibleItem>());
			gear.GetComponent<GearItem>().m_MissionObject = null;

            gear = GearItem.LoadGearItemPrefab("GEAR_Camera").gameObject;

            gear.GetComponent<GearItem>().m_CantDropItem = false;
            gear.GetComponent<GearItem>().m_GearItemData.m_CantDrop = false;
            gear.GetComponent<GearItem>().m_GearItemData.m_IsPlaceable = true;
            gear.GetComponent<GearItem>().m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(0.3f);
			gear.GetComponent<GearItem>().m_GearItemData.m_RemainInInventoryOnDrop = false;

            gear = GearItem.LoadGearItemPrefab("GEAR_Respirator").gameObject;

            gear.GetComponent<GearItem>().m_CantDropItem = false;
            gear.GetComponent<GearItem>().m_GearItemData.m_CantDrop = false;
            gear.GetComponent<GearItem>().m_GearItemData.m_IsPlaceable = true;
            gear.GetComponent<GearItem>().m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(0.75f);
            gear.GetComponent<GearItem>().m_GearItemData.m_RemainInInventoryOnDrop = false;




        }

    }
}