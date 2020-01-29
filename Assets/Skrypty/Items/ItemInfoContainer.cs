/**
 * 
 * 		TEN SKRYPT ZNAJDUJE SIE W IKONIE PRZEDMIOTU W EKWIPUNKU
 * 
**/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemInfoContainer : MonoBehaviour {
	
	public string itemName;
	public string itemRarity;
	public string itemLevel;
	public string staminaValue;
	public SecondaryStat secondaryStatValueName;
	public string secondaryStatValue;
	public BonusStat bonusValue1Name;
	public string bonusValue1;
	public BonusStat bonusValue2Name;
	public string bonusValue2;
	public BonusStat bonusValue3Name;
	public string bonusValue3;
	public string requiredLevel;
	public string minDamage;
	public string maxDamage;
	public string bonusAbility;
	public EquipableSlot itemType;
	public string itemID;
	public string optionalBuffID;
	public string armorValue;
	public string equipCost;
	public GameObject item;
	public GameObject optionalActiveBuff;
	public int minBufor;
	public int maxBufor;
	object[] data;

	public bool isEquiped = false;

	public void SetVariables(object[] infoReceived)
	{
		data = infoReceived;
		itemName = infoReceived[0].ToString();
		itemRarity = infoReceived[1].ToString();
		itemLevel = infoReceived[2].ToString();
		staminaValue = infoReceived[3].ToString();
		secondaryStatValueName = (SecondaryStat)infoReceived [4];
		secondaryStatValue= infoReceived[5].ToString();
		bonusValue1Name = (BonusStat)infoReceived [6];
		bonusValue1=infoReceived[7].ToString();
		bonusValue2Name = (BonusStat)infoReceived [8];
		bonusValue2=infoReceived[9].ToString();
		bonusValue3Name = (BonusStat)infoReceived [10];
		bonusValue3=infoReceived[11].ToString();
		itemType = (EquipableSlot)infoReceived [12];
		requiredLevel = infoReceived [13].ToString ();
		minDamage = infoReceived [14].ToString ();
		maxDamage = infoReceived [15].ToString ();
		bonusAbility = infoReceived [16].ToString ();
		itemID = infoReceived [17].ToString ();
		optionalBuffID = infoReceived [18].ToString ();
		armorValue = infoReceived [19].ToString ();
		equipCost = infoReceived [20].ToString ();
	}
	void SlotChanged()//zła nazwa, OnEquip
	{
		#region Add statistics to player
		//Region do usuniecia jezeli wykorzysta sie #WID_0004-1.1//
		if (!isEquiped) {
			isEquiped=true;
			item = Instantiate(Resources.Load("Prefabrykaty/"+itemID, typeof(GameObject))) as GameObject; // itemID np WID_0400 musi być w folderze Resources
			if(optionalBuffID != "")
			{
				int emptySlotID = InventoryManager.GetEmptySlot();
				if (emptySlotID != -1) {
					optionalActiveBuff = Instantiate(Resources.Load("Prefabrykaty/Buffs/"+optionalBuffID, typeof(GameObject))) as GameObject;
					optionalActiveBuff.transform.parent = BuffManager.buffSlots[emptySlotID].transform;
					optionalActiveBuff.transform.position = BuffManager.buffSlots[emptySlotID].transform.position;
					optionalActiveBuff.transform.localScale = new Vector3 (1f, 1f, 1f);
				}
			}

			item.SendMessage("SetVariables", data);
			item.GetComponent<Item>().EquipItemOnHandler();
			BazaDanych.bonusSTA += int.Parse (staminaValue);
			if (secondaryStatValueName == SecondaryStat.Intellect) {
				BazaDanych.bonusINT += int.Parse (secondaryStatValue);
			} else if (secondaryStatValueName == SecondaryStat.Agility) {
				BazaDanych.bonusAGI += int.Parse (secondaryStatValue);
			} else if (secondaryStatValueName == SecondaryStat.Strenght) {
				BazaDanych.bonusSTR += int.Parse (secondaryStatValue);
			}else if (secondaryStatValueName == SecondaryStat.Spirit) {
				BazaDanych.bonusSPR += int.Parse (secondaryStatValue);
			}

			if(bonusValue1Name == BonusStat.CriticalChance)
			{
				BazaDanych.bonusDMG += int.Parse(bonusValue1);	
			}

			BazaDanych.minDamageValue += minBufor = int.Parse(minDamage)+BazaDanych.bonusDMG;
			BazaDanych.maxDamageValue += maxBufor = int.Parse(maxDamage)+BazaDanych.bonusDMG;
		}
		#endregion
		BazaDanych.Refresh ();

		//gameObject.AddComponent<BID_0002> ();
		//"Bla bla bla, tu ColorSpace wpisz ".RunEffect();
	}
	void OnDisrobe()
	{
		if (isEquiped) {
			isEquiped = false;
			if (optionalBuffID != "") {
				Destroy(GameObject.FindGameObjectWithTag(optionalBuffID));
			}

			//Destroy (item);
			BazaDanych.bonusSTA -= int.Parse (staminaValue);
			if (secondaryStatValueName == SecondaryStat.Intellect) {
				BazaDanych.bonusINT -= int.Parse (secondaryStatValue);
			} else if (secondaryStatValueName == SecondaryStat.Agility) {
				BazaDanych.bonusAGI -= int.Parse (secondaryStatValue);
			} else if (secondaryStatValueName == SecondaryStat.Strenght) {
				BazaDanych.bonusSTR -= int.Parse (secondaryStatValue);
			}else if (secondaryStatValueName == SecondaryStat.Spirit) {
				BazaDanych.bonusSPR -= int.Parse (secondaryStatValue);
			}

			BazaDanych.minDamageValue -= minBufor; //odejmujemy tylko to co dodalismy
			BazaDanych.maxDamageValue -= maxBufor;

			BazaDanych.Refresh ();
		}
	}
}
