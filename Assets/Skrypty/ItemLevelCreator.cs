/**
 * 
 * 	TEN SKRYPT BĘDZIE SŁUŻYĆ DO WYLOSOWANIA STATYSTYK PRZEDMIOTU (RANDOM DROP)
 *  
 * 
**/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemLevelCreator : MonoBehaviour {

	public bool upgradeRoll=false;
	[Header("Podgląd na wygenerowany item")]
	public string itemID;
	public string optionalBuffID;
	public string itemName;
	public ItemRarity itemRarity;
	public int itemLevel;
	public int requiredLevel;
	public int staminaValue;
	public SecondaryStat secondaryStatValueName;
	public int secondaryStatValue;
	public int equipCost=0;
	public int bonusValue1=0;
	public int bonusValue2=0;
	public int bonusValue3=0;
	public BonusStat bonusValue1Name;
	public BonusStat bonusValue2Name;
	public BonusStat bonusValue3Name;
	public string bonusAbility;
	public EquipableSlot itemType; //zostawić puste, wypełnia się samo
	//public EquipableSlot canBeEquipedInSlot;
	public int minDamage;
	public int maxDamage;
	public float ilvlBase;
	public float damageBase;
	public float randomFactorMin;
	public float randomFactorMmax;
	public float ilvlUsageMin;
	public float ilvlUsageMax;
	[Header("Modyfikatory")]

	public float rawDamageMod;
	public float armorMod;
	public float damageMod;
	public float criticalMod;
	public float lifestealMod;
	public float hasteMod;
	public float magicMod;
	public float physicMod;
	public float manaMod;
	public float healthMod;
	public float diffMod=0;
	public float intMod;
	public float slotMod;
	[Header("Podgląd")]
	public float ilvlBudget=0f;
	public float ilvlPrimaryBudget=0;
	public float ilvlSecontaryBudget=0;
	public float randomFactor=0;
	public static object[] itemInfo = new object[21];

	float ilvlUsage;
	float primaryRoll;
	float secondaryRoll;
	int armorValue;
	int statName;
	bool enableBonus1=false;
	bool enableBonus2=false;
	bool enableBonus3=false;
	//string itemType;
	//int randomSlotMod;
	//int randomSlotItem;

	public void CreateNew(ItemRarity rarity, int ilvl, int rlvl, int customDamageBase, EquipableSlot iType)
	{
		if (rarity == ItemRarity.RandomGen) {
			rarity = (ItemRarity)Random.Range (0, 5);
		}
		if (ilvl == 0) {
			ilvl = BazaDanych.playerLevel * 2;
		}
		itemRarity = rarity;
		itemLevel = ilvl;
		requiredLevel = rlvl;
		itemType = iType;
		if (itemType == EquipableSlot.None) {
			while (true) {
				itemType = (EquipableSlot)Random.Range (0, 17);
				if (itemType == EquipableSlot.None || itemType == EquipableSlot.WeaponAll || itemType == EquipableSlot.Weapon) {
					continue;
				} else {
					break;
				}
			}
		}

		if (itemType == EquipableSlot.Chest || itemType == EquipableSlot.Head || itemType == EquipableSlot.Legs || itemType == EquipableSlot.WeaponAll) {
			slotMod = 1.0f;
		} else if (itemType == EquipableSlot.Feet || itemType == EquipableSlot.Hands || itemType == EquipableSlot.Shoulder || itemType == EquipableSlot.Waist || itemType == EquipableSlot.Wrist || itemType == EquipableSlot.Weapon1) {
			slotMod = 0.75f;
		} else {
			slotMod = 0.33f;
		}

		if (itemRarity == ItemRarity.Common) {
			ilvlBase = 30;
			damageBase = 30;
			enableBonus1 = false;
			enableBonus2 = false;
			enableBonus3 = false;
		} else if (itemRarity == ItemRarity.Uncommon) {
			ilvlBase = 50;
			damageBase = 34;
			enableBonus1 = true;
			enableBonus2 = false;
			enableBonus3 = false;
		} else if (itemRarity == ItemRarity.Rare) {
			ilvlBase = 70;
			damageBase = 38;
			enableBonus1 = true;
			enableBonus2 = true;
			enableBonus3 = false;
		} else if (itemRarity == ItemRarity.Epic) {
			ilvlBase = 95;
			damageBase = 42;
			enableBonus1 = true;
			enableBonus2 = true;
			enableBonus3 = true;
		} else if (itemRarity == ItemRarity.Legendary) {
			ilvlBase = 120;
			damageBase = 46;
			enableBonus1 = true;
			enableBonus2 = true;
			enableBonus3 = true;
		}
		//randomSlotMod = Random.Range(0,3);


		//Przygotowanie zmiennych i ustalenie budżetu
		ilvl = itemLevel;
		rlvl = requiredLevel;
		ilvlBudget = (ilvlBase / 100f);
		ilvlPrimaryBudget = ilvlBudget * Random.Range (ilvlUsageMin, ilvlUsageMax);
		ilvlBudget = ilvlBudget - ilvlPrimaryBudget;
		ilvlSecontaryBudget = ilvlBudget * Random.Range (0.6f, 0.9f);

		ilvlBudget = (ilvlBudget - ilvlSecontaryBudget);// * commonPer;
		randomFactor = (Random.Range (randomFactorMin, randomFactorMmax) / 100);

		//właściwe generowanie statystyk
		primaryRoll = (((ilvl* ilvlPrimaryBudget)*randomFactor)*slotMod);
		secondaryRoll = (((ilvl* ilvlSecontaryBudget)*randomFactor)*slotMod);

		diffMod = (primaryRoll / secondaryRoll);
		staminaValue = (int)primaryRoll;
		secondaryStatValue = (int)secondaryRoll;

		armorValue = (int)((primaryRoll+secondaryRoll)*randomFactor*armorMod*slotMod);

		if (itemType == EquipableSlot.Weapon1 || itemType==EquipableSlot.Weapon2) {
			if (customDamageBase!=0) {
				maxDamage = (int)(((ilvl * ilvlPrimaryBudget * customDamageBase) * randomFactor) * rawDamageMod);
				minDamage = (int)(maxDamage * 0.75f);
			} else {
				maxDamage = (int)(((ilvl * ilvlPrimaryBudget * damageBase) * randomFactor) * rawDamageMod);
				minDamage = (int)(maxDamage * 0.75f);
			}
		} else {
			maxDamage = 0;
			minDamage = 0;
		}
		//losowanie statystyki dodatkowej
		statName = Random.Range (0, 4);
		if (statName == 0) {
			secondaryRoll = (int)(secondaryRoll* intMod);
		}

		if (enableBonus1) {
			bonusValue1Name = (BonusStat)Random.Range (0, 9);
			bonusValue1 = (int)((ilvl * ilvlBudget * diffMod*3)*(1/diffMod)*slotMod);
			if (bonusValue1Name == BonusStat.Armor)
				bonusValue1 = (int)(bonusValue1 * armorMod);
			if (bonusValue1Name == BonusStat.Damage)
				bonusValue1 = (int)(bonusValue1 * damageMod);
			if (bonusValue1Name == BonusStat.CriticalChance)
				bonusValue1 = (int)(bonusValue1 * criticalMod);
			if (bonusValue1Name == BonusStat.Lifesteal)
				bonusValue1 = (int)(bonusValue1 * lifestealMod);
			if (bonusValue1Name == BonusStat.Haste)
				bonusValue1 = (int)(bonusValue1 * hasteMod);
			if (bonusValue1Name == BonusStat.MagicResistance)
				bonusValue1 = (int)(bonusValue1 * magicMod);
			if (bonusValue1Name == BonusStat.PhysicResistance)
				bonusValue1 = (int)(bonusValue1 * physicMod);
			if (bonusValue1Name == BonusStat.ManaSec)
				bonusValue1 = (int)(bonusValue1 * manaMod);
			if (bonusValue1Name == BonusStat.HelathSec)
				bonusValue1 = (int)(bonusValue1 * healthMod);
		}
		if (enableBonus2) {
			do {
				bonusValue2Name = (BonusStat)Random.Range (0, 9);
			} while(bonusValue2Name == bonusValue1Name);

			bonusValue2 = (int)((ilvl * ilvlBudget * diffMod*3)*(1/diffMod)*slotMod);
			if (bonusValue2Name == BonusStat.Armor)
				bonusValue2 = (int)(bonusValue2 * armorMod);
			if (bonusValue2Name == BonusStat.Damage)
				bonusValue2 = (int)(bonusValue2 * damageMod);
			if (bonusValue2Name == BonusStat.CriticalChance)
				bonusValue2 = (int)(bonusValue2 * criticalMod);
			if (bonusValue2Name == BonusStat.Lifesteal)
				bonusValue2 = (int)(bonusValue2 * lifestealMod);
			if (bonusValue2Name == BonusStat.Haste)
				bonusValue2 = (int)(bonusValue2 * hasteMod);
			if (bonusValue2Name == BonusStat.MagicResistance)
				bonusValue2 = (int)(bonusValue2 * magicMod);
			if (bonusValue2Name == BonusStat.PhysicResistance)
				bonusValue2 = (int)(bonusValue2 * physicMod);
			if (bonusValue2Name == BonusStat.ManaSec)
				bonusValue2 = (int)(bonusValue2 * manaMod);
			if (bonusValue2Name == BonusStat.HelathSec)
				bonusValue2 = (int)(bonusValue2 * healthMod);
		}
		if (enableBonus3) {
			do {
				bonusValue3Name = (BonusStat)Random.Range (0, 9);
			} while(bonusValue3Name == bonusValue1Name || bonusValue3Name == bonusValue2Name);

			bonusValue3 = (int)((ilvl * ilvlBudget * diffMod*3)*(1/diffMod)*slotMod);
			if (bonusValue3Name == BonusStat.Armor)
				bonusValue3 = (int)(bonusValue3 * armorMod);
			if (bonusValue3Name == BonusStat.Damage)
				bonusValue3 = (int)(bonusValue3 * damageMod);
			if (bonusValue3Name == BonusStat.CriticalChance)
				bonusValue3 = (int)(bonusValue3 * criticalMod);
			if (bonusValue3Name == BonusStat.Lifesteal)
				bonusValue3 = (int)(bonusValue3 * lifestealMod);
			if (bonusValue3Name == BonusStat.Haste)
				bonusValue3 = (int)(bonusValue3 * hasteMod);
			if (bonusValue3Name == BonusStat.MagicResistance)
				bonusValue3 = (int)(bonusValue3 * magicMod);
			if (bonusValue3Name == BonusStat.PhysicResistance)
				bonusValue3 = (int)(bonusValue3 * physicMod);
			if (bonusValue3Name == BonusStat.ManaSec)
				bonusValue3 = (int)(bonusValue3 * manaMod);
			if (bonusValue3Name == BonusStat.HelathSec)
				bonusValue3 = (int)(bonusValue3 * healthMod);
		}

		itemInfo [0] = "RandomItem";
		itemInfo [1] = itemRarity;
		itemInfo [2] = itemLevel;
		itemInfo [3] = staminaValue;
		itemInfo [4] = secondaryStatValueName;
		itemInfo [5] = secondaryStatValue;
		itemInfo [6] = bonusValue1Name;
		itemInfo [7] = bonusValue1;
		itemInfo [8] = bonusValue2Name;
		itemInfo [9] = bonusValue2;
		itemInfo [10] = bonusValue3Name;
		itemInfo [11] = bonusValue3;
		itemInfo [12] = itemType;
		itemInfo [13] = requiredLevel;
		itemInfo [14] = minDamage;
		itemInfo [15] = maxDamage;
		itemInfo [16] = bonusAbility;
		itemInfo [17] = itemID;
		itemInfo [18] = optionalBuffID;
		itemInfo [19] = armorValue;
		itemInfo [20] = equipCost;
	}

	public object GetItemInfo()
	{
		return itemInfo;
	}
}
