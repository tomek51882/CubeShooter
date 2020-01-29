/**
 * 
 * 	TEN SKRYPT TO MÓZG APLIKACJI. PRZECHOWUJE WSZYSTKIE ZMIENNE KTÓRE 
 *  MUSZĄ BYĆ PUBLICZNE, DOSTĘPNE Z KAŻDEGO MIEJSCA I DLA KAŻDEGO SKRYPTU.
 * 
**/

using UnityEngine;
using System.Collections;
public enum ItemRarity{
	Common,Uncommon,Rare,Epic,Legendary,Broken,RandomGen
}
public enum SecondaryStat {
	Intellect,Agility,Strenght,Spirit,Void
}
public enum EquipableSlot{
	None,Head,Neck,Trinket,Shoulder,Back,Hands,Chest,Wrist,Ring,Waist,Legs,Feet,Weapon,Weapon1,Weapon2,WeaponAll
}
public enum BonusStat{
	None,CriticalChance,Damage,Armor,Haste,Lifesteal,ManaSec,HelathSec,MagicResistance,PhysicResistance 
}

public class BazaDanych : MonoBehaviour {

	//------------------------------------------------------
	//GLOWNE ZMIENNE
	public static int playerLevel = 1;
	public static string playerName = "Player";
	public static float playerHitPoints = 0;
	public static int playerMaxHitPoints = 0;
	public static float playerManaPoints = 0;
	public static int playerMaxManaPoints = 0;
	public static float playerSpecialEnergy = 0;
	public static int playerMaxSpecialEnergy = 0;

	public static int playerAgi = 0;
	public static int playerStr = 0;
	public static int playerSpr = 0;
	public static int playerVoi = 0;
	public static int playerCor = 0;

	public static float expToNextLevel = 500;
	public static int playerExp = 0;
	//------------------------------------------------------
	//TARGET
	public static string targetName = "[Target]";
	public static float targetHitPoints = 0;
	public static float targetMaxHitPoints = 0;
	public static float targetArmorPoints = 0;

	//------------------------------------------------------
	//STATYSTYKI BAZOWE
	public static int sta = 10;
	public static int inte = 5;
	public static int agi = 3;
	public static int str = 3;
	public static int spr = 3;

	public static int armorValue=0;
	public static int minDamageValue=0;
	public static int maxDamageValue=0;
	public static int criticalChanceValue=0;
	public static int lifeSteal=0;
	public static int movementSpeed=100;
	//endgame stats
	public static int voi = 0;
	public static int cor = 0;
	//------------------------------------------------------
	//BONUSY
	public static int bonusDMG = 0;
	public static int bonusSPD = 0;
	public static int bonusLS = 0;

	public static int bonusSTA = 0;
	public static int bonusINT = 0;
	public static int bonusAGI = 0;
	public static int bonusSTR = 0;
	public static int bonusSPR = 0;

	public static int bonusVOI = 0;
	public static int bonusCOR = 0;
	//------------------------------------------------------
	//SUROWCE
	public static int Eptagenium = 0;
	public static int Poleryan = 0;
	public static int Xyndrian = 0;
	//------------------------------------------------------
	//INNE
	public static int damageDealt = 0;
	public static int manaUsed = 0;
	public static int energyUsed = 0;
	public static int statisticsPoint = 11;
	public static int attributesPoint = 0;
	public static bool canEquipMoreWeapons=true;
	#region REWORK HERE
	public static string spellName;
	public static int spellCost;
	public static int spellCooldown;
	public static string spellDesc;
	#endregion
	//------------------------------------------------------
	//BOOL
	public static bool showTarget = false;
	public static bool dungeonMode = false;
	public static bool vehicleMode = false;
	public static bool combatMode = false;
	public static bool showQuestInfo = false;
	public static bool showQuestLog = false;
	public static bool questAccepted = false;
	public static int showCursor = 0;
	//------------------------------------------------------
	//COOLDOWNY SPELLI
	public static float cooldownSpell1;
	public static float cooldownSpell2;
	public static float cooldownSpell3;
	public static float cooldownSpell4;
	public static float cooldownSpell5;
	public static float cooldownSpell6;
	public static float cooldownSpell7;
	public static float cooldownSpell8;
	public static float cooldownSpell9;
	public static float cooldownSpell10;
	//------------------------------------------------------
	//KOLORKI
	public static Color hostileHealthColor;
	public static Color hostileHealthColorTarget;
	public static Color neutralHealthColor;
	public static Color neutralHealthColorTarget;
	public static Color friendlyHealthColor;
	public static Color friendlyHealthColorTarget;
	public static Color textColor;
	public static Color textColorTarget;

	//------------------------------------------------------
	//QUESTY
	public static string questName;
	public static string questDescription;
	public static string questObjective;
	public static string questReward;
	public static int xpReward;

	void Awake()
	{
		Application.targetFrameRate = 60;
		playerMaxHitPoints=(sta + bonusSTA) * 10 + (playerLevel * 15);
		playerMaxManaPoints = (inte + bonusINT) * 10 + (playerLevel * 7);

		playerHitPoints = playerMaxHitPoints;
		playerManaPoints = playerMaxManaPoints;
		playerAgi = (agi + bonusAGI) * 5;
		playerStr = (str + bonusSTR) * 5;
		playerSpr = (spr + bonusSPR) * 5;
		playerVoi = (voi + bonusVOI) * 5;
		playerCor = (cor + bonusCOR) * 5;

		hostileHealthColor.r = 1f;
		hostileHealthColor.a = .4f;
		hostileHealthColorTarget.r = 1f;
		hostileHealthColorTarget.a = 1f;

		neutralHealthColor.r=1f;
		neutralHealthColor.g=.67f;
		neutralHealthColor.a = .4f;
		neutralHealthColorTarget.r=1f;
		neutralHealthColorTarget.g=.67f;
		neutralHealthColorTarget.a = 1f;

		friendlyHealthColor.g=.67f;
		friendlyHealthColor.a=.4f;
		friendlyHealthColorTarget.g=.67f;
		friendlyHealthColorTarget.a=1f;

		textColor.r=0;
		textColor.g=0;
		textColor.b = 0;
		textColor.a=.4f;
		textColorTarget.r=0;
		textColorTarget.g=0;
		textColorTarget.b=0;
		textColorTarget.a=1f;
	}

	public static void Load()
	{
		
	}
	public static void Save()
	{
		
	}

	public static void Refresh()
	{
		playerMaxHitPoints=(sta + bonusSTA) * 10 + (playerLevel * 15);
		playerMaxManaPoints = (inte + bonusINT) * 10 + (playerLevel * 7);
		playerAgi = (agi + bonusAGI) * 5;
		playerStr = (str + bonusSTR) * 5;
		playerSpr = (spr + bonusSPR) * 5;
		playerVoi = (voi + bonusVOI) * 5;
		playerCor = (cor + bonusCOR) * 5;
	}
}
