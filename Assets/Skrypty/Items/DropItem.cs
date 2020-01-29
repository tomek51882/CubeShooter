using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {
	//bool canSpawn=true;
	public GameObject spawnPoint;
	public GameObject item;
	public EquipableSlot itemType;

	public void Action()
	{
		while (true) {
			itemType = (EquipableSlot)Random.Range (0, 17);
			if (itemType == EquipableSlot.None || itemType == EquipableSlot.WeaponAll || itemType == EquipableSlot.Weapon) {
				continue;
			} else {
				break;
			}
		}
		if (itemType == EquipableSlot.Weapon1 || itemType == EquipableSlot.Weapon2) {
			item = Instantiate (Resources.Load ("Prefabrykaty/WID_0400", typeof(GameObject))) as GameObject;
			//item = Instantiate (Resources.Load ("Prefabrykaty/WID_"+itemBaseGen, typeof(GameObject))) as GameObject;

		} else {
			item = Instantiate (Resources.Load ("Prefabrykaty/TestItem001", typeof(GameObject))) as GameObject;
		}
		item.transform.position = spawnPoint.transform.position;
		GameObject itemGen = GameObject.FindGameObjectWithTag ("ItemGenerator");
		itemGen.GetComponent<ItemLevelCreator> ().CreateNew (ItemRarity.RandomGen, 10, 1, 0, itemType);
		item.SendMessage ("SetVariables", itemGen.GetComponent<ItemLevelCreator> ().GetItemInfo ());
	}
}
