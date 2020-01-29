/**
 * 
 * 	TEN SKRYPT BĘDZIE SŁUŻYĆ DO WYLOSOWANIA STATYSTYK PRZEDMIOTU (RANDOM DROP)
 * 
 * 
**/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemLevelCreator1 : MonoBehaviour {

	public Text enteredItemLevel;
	public Text rarity;
	public bool upgradeRoll=true;

	public string[] secondaryStats;
	public string[] bonusStats;

	public Text tRariry;
	public Text tItemLevel;
	public Text tUpgradedTimes;
	public Text tPrimary;
	public Text tSecondary;
	public Text tBonus1;
	public Text tBonus2;
	public Text tBonus3;
	public Text tBonusCost;
	public Text tIsEnchantable;
	public Text tHasAbility;

	public int commonPer;
	public int uncommonPer;
	public int rarePer;
	public int epicPer;
	public int legendaryPer;

	int ilvl;
	int upgradedIlvl;
	int upgradeCount;

	int primaryRoll;
	int secondaryRoll;

	int bonusCountRoll;
	int bonusCost;

	bool isEnchantable = false;
	bool hasAbility = false;

	public void Create()
	{
		ilvl = int.Parse (enteredItemLevel.text);
		upgradedIlvl = ilvl;
		upgradeCount = 0;
		int ilvlUsageRemain;
		int randomValue;

		if (rarity.text == "common") {
			
			tRariry.text = "Common";
			tRariry.color = Color.white;
			//------------------------------------------------------
			//OBLICZANIE POZIOMU WYKORZYSTANIA ILVLA DO STATYSTYK
			ilvlUsageRemain = commonPer;
			randomValue = Random.Range (15, 20);
			ilvlUsageRemain = ilvlUsageRemain - randomValue;
			//------------------------------------------------------
			//ULEPSZANIE BASE ITEM LEVELA
			if (upgradeRoll) {
				while (true) {
					if (Random.Range (1, 100) > 50) {
						upgradedIlvl = upgradedIlvl + 5;
						upgradeCount++;
					} else {
						break;
					}
				}
			}
			//------------------------------------------------------
			//LOSOWANIE STATYSTYKI PODSTAWOWEJ NA PODSTAWIE ILVL
			primaryRoll = (int)(upgradedIlvl * (randomValue/100.0f));
			tPrimary.text = primaryRoll.ToString() + " Stamina";
			//------------------------------------------------------
			//LOSOWANIE STATYSTYKI DODATKOWEJ NA PODSTAWIE POZOSTALEGO WYKORZYSTANIA ILVLA
			secondaryRoll = (int)(upgradedIlvl * (ilvlUsageRemain/100.0f));
			tSecondary.text = secondaryRoll + " "+ secondaryStats [Random.Range (0, 4)];


			tItemLevel.text = "ilvl " + upgradedIlvl.ToString ();
			tUpgradedTimes.text = "Item upgraded " + upgradeCount.ToString() + " times";
			tBonus1.text = "Bonus stat: None";
			tBonus2.text = "Bonus stat: None";
			tBonus3.text = "Bonus stat: None";
			tBonusCost.text = "Bonus cost: 0";
			tIsEnchantable.text = "Is enchantable: No";
			tHasAbility.text = "Has ability: No ";
		}
		else if (rarity.text == "uncommon") {

			tRariry.text = "Uncommon";
			tRariry.color = Color.green;
			//------------------------------------------------------
			//OBLICZANIE POZIOMU WYKORZYSTANIA ILVLA DO STATYSTYK
			ilvlUsageRemain = uncommonPer;
			randomValue = Random.Range (18, 30);
			ilvlUsageRemain = ilvlUsageRemain - randomValue;
			//------------------------------------------------------
			//ULEPSZANIE BASE ITEM LEVELA
			if (upgradeRoll) {
				while (true) {
					if (Random.Range (1, 100) > 50) {
						upgradedIlvl = upgradedIlvl + 5;
						upgradeCount++;
					} else {
						break;
					}
				}
			}
			//------------------------------------------------------
			//LOSOWANIE STATYSTYKI PODSTAWOWEJ NA PODSTAWIE ILVL
			primaryRoll = (int)(upgradedIlvl * (randomValue/100.0f));
			tPrimary.text = primaryRoll.ToString() + " Stamina";
			//------------------------------------------------------
			//LOSOWANIE STATYSTYKI DODATKOWEJ NA PODSTAWIE POZOSTALEGO WYKORZYSTANIA ILVLA
			secondaryRoll = (int)(upgradedIlvl * (ilvlUsageRemain/100.0f));
			tSecondary.text = secondaryRoll + " "+ secondaryStats [Random.Range (0, 4)];


			tItemLevel.text = "ilvl " + upgradedIlvl.ToString ();
			tUpgradedTimes.text = "Item upgraded " + upgradeCount.ToString() + " times";
			tBonus1.text = "Bonus stat: None";
			tBonus2.text = "Bonus stat: None";
			tBonus3.text = "Bonus stat: None";
			tBonusCost.text = "Bonus cost: 0";
			tIsEnchantable.text = "Is enchantable: No";
			tHasAbility.text = "Has ability: No ";
		} else if (rarity.text == "rare") {

			tRariry.text = "Rare";
			tRariry.color = Color.blue;
			//------------------------------------------------------
			//OBLICZANIE POZIOMU WYKORZYSTANIA ILVLA DO STATYSTYK
			ilvlUsageRemain = rarePer;
			randomValue = Random.Range (30, 42);
			ilvlUsageRemain = ilvlUsageRemain - randomValue;
			//------------------------------------------------------
			//ULEPSZANIE BASE ITEM LEVELA
			if (upgradeRoll) {
				while (true) {
					if (Random.Range (1, 100) > 50) {
						upgradedIlvl = upgradedIlvl + 5;
						upgradeCount++;
					} else {
						break;
					}
				}
			}
			//------------------------------------------------------
			//LOSOWANIE STATYSTYKI PODSTAWOWEJ NA PODSTAWIE ILVL
			primaryRoll = (int)(upgradedIlvl * (randomValue/100.0f));
			tPrimary.text = primaryRoll.ToString() + " Stamina";
			//------------------------------------------------------
			//LOSOWANIE STATYSTYKI DODATKOWEJ NA PODSTAWIE POZOSTALEGO WYKORZYSTANIA ILVLA
			secondaryRoll = (int)(upgradedIlvl * (ilvlUsageRemain/100.0f));
			tSecondary.text = secondaryRoll + " "+ secondaryStats [Random.Range (0, 4)];


			tItemLevel.text = "ilvl " + upgradedIlvl.ToString ();
			tUpgradedTimes.text = "Item upgraded " + upgradeCount.ToString() + " times";

			tBonus1.text = "Bonus stat: +"+ (int)(upgradedIlvl/6)+" "+bonusStats[Random.Range (0, 5)];
			tBonus2.text = "Bonus stat: None";
			tBonus3.text = "Bonus stat: None";
			tBonusCost.text = "Bonus cost: 0";


			tIsEnchantable.text = "Is enchantable: No";
			tHasAbility.text = "Has ability: No ";
		} else if (rarity.text == "epic") {

			tRariry.text = "Epic";
			tRariry.color = Color.magenta;
			//------------------------------------------------------
			//OBLICZANIE POZIOMU WYKORZYSTANIA ILVLA DO STATYSTYK
			ilvlUsageRemain = epicPer;
			randomValue = Random.Range (40, 60);
			ilvlUsageRemain = ilvlUsageRemain - randomValue;
			//------------------------------------------------------
			//ULEPSZANIE BASE ITEM LEVELA
			if (upgradeRoll) {
				while (true) {
					if (Random.Range (1, 100) > 50) {
						upgradedIlvl = upgradedIlvl + 5;
						upgradeCount++;
					} else {
						break;
					}
				}
			}
			//------------------------------------------------------
			//LOSOWANIE STATYSTYKI PODSTAWOWEJ NA PODSTAWIE ILVL
			primaryRoll = (int)(upgradedIlvl * (randomValue/100.0f));
			tPrimary.text = primaryRoll.ToString() + " Stamina";
			//------------------------------------------------------
			//LOSOWANIE STATYSTYKI DODATKOWEJ NA PODSTAWIE POZOSTALEGO WYKORZYSTANIA ILVLA
			secondaryRoll = (int)(upgradedIlvl * (ilvlUsageRemain/100.0f));
			tSecondary.text = secondaryRoll + " "+ secondaryStats [Random.Range (0, 4)];


			tItemLevel.text = "ilvl " + upgradedIlvl.ToString ();
			tUpgradedTimes.text = "Item upgraded " + upgradeCount.ToString() + " times";
			// + Random.Range(ilvlUsageRemain/4,ilvlUsageRemain/2)
			tBonus1.text = "Bonus stat: +"+ (int)(upgradedIlvl*(10f/100f)+ilvlUsageRemain/4)+" "+bonusStats[Random.Range (0, 5)];
			tBonus2.text = "Bonus stat: +"+ (int)(upgradedIlvl/6)+" "+bonusStats[Random.Range (0, 5)];
			while (true) {
				if (tBonus2.text == tBonus1.text) {
					tBonus2.text = "Bonus stat: +" + (int)(upgradedIlvl/6) + " " + bonusStats [Random.Range (0, 5)];
				} else {
					break;
				}
			}
			tBonus3.text = "Bonus stat: None";
			tBonusCost.text = "Bonus cost: 0";


			tIsEnchantable.text = "Is enchantable: No";
			tHasAbility.text = "Has ability: No ";
		} else if (rarity.text == "legendary") {

			tRariry.text = "Legendary";
			tRariry.color = Color.yellow;
			//------------------------------------------------------
			//OBLICZANIE POZIOMU WYKORZYSTANIA ILVLA DO STATYSTYK
			ilvlUsageRemain = legendaryPer;
			randomValue = Random.Range (60, 70);
			ilvlUsageRemain = ilvlUsageRemain - randomValue;
			//------------------------------------------------------
			//ULEPSZANIE BASE ITEM LEVELA
			if (upgradeRoll) {
				while (true) {
					if (Random.Range (1, 100) > 50) {
						upgradedIlvl = upgradedIlvl + 8;
						upgradeCount++;
					} else {
						break;
					}
				}
			}
			//------------------------------------------------------
			//LOSOWANIE STATYSTYKI PODSTAWOWEJ NA PODSTAWIE ILVL
			primaryRoll = (int)(upgradedIlvl * (randomValue/100.0f) + upgradedIlvl/1.2f);
			tPrimary.text = primaryRoll.ToString() + " Stamina";
			//------------------------------------------------------
			//LOSOWANIE STATYSTYKI DODATKOWEJ NA PODSTAWIE POZOSTALEGO ILVLA
			secondaryRoll = (int)(upgradedIlvl * (ilvlUsageRemain/100.0f)+ upgradedIlvl/2);
			tSecondary.text = secondaryRoll + " "+ secondaryStats [Random.Range (0, 4)];


			tItemLevel.text = "ilvl " + upgradedIlvl.ToString ();
			tUpgradedTimes.text = "Item upgraded " + upgradeCount.ToString() + " times";
			//------------------------------------------------------
			//LOSOWANIE STATYSTYK BONUSOWYCH
			tBonus1.text = "Bonus stat: +"+ (int)(upgradedIlvl/1.8f)+" "+bonusStats[Random.Range (0, 5)];
			tBonus2.text = "Bonus stat: +"+ (int)(upgradedIlvl/1.8f)+" "+bonusStats[Random.Range (0, 5)];
			while (true) {
				if (tBonus2.text == tBonus1.text) {
					tBonus2.text = "Bonus stat: +" + (int)(upgradedIlvl / 1.8f) + " " + bonusStats [Random.Range (0, 5)];
				} else {
					break;
				}
			}
			tBonus3.text = "Bonus stat: +"+ (int)(upgradedIlvl/1.8f)+" "+bonusStats[Random.Range (0, 5)];
			while (true) {
				if (tBonus3.text == tBonus1.text || tBonus3.text == tBonus2.text) {
					tBonus3.text = "Bonus stat: +" + (int)(upgradedIlvl / 1.8f) + " " + bonusStats [Random.Range (0, 5)];
				} else {
					break;
				}
			}
			tBonusCost.text = "Bonus cost: 0";


			tIsEnchantable.text = "Is enchantable: No";
			tHasAbility.text = "Has ability: No ";
		}

	}
	public void UpgradeRollChange()
	{
		upgradeRoll = !upgradeRoll;
	}
}
