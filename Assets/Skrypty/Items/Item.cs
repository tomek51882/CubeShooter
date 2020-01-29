/**
 *  TEN SKRYPT MUSI ZASTĄPIĆ CZĘŚĆ WID_0400!!!
 * 	TEN SKRYPT MUSI BYĆ W KAŻDYM ITEMIE. 
 * 	ITEM TYPE JEST ZDUBLOWANY!!!!!
 * 
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

	public Sprite icon;
	public GameObject itemObject;
	public bool equiped=false;
	public string itemID;
	public string optionalBuffID; //buff gdy broń jest wyposażona
	public GameObject buff;
	public GameObject interactionCanvas;


	[Header("ItemInfo")]
	public string itemName;
	public ItemRarity itemRarity;

	public int itemLevel;
	public int requiredLevel;

	public int staminaValue;
	public SecondaryStat secondaryStatValueName;
	public int secondaryStatValue;

	public int armorValue=0;
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
	bool itemTargeted = false;

	public void EquipItemOnHandler()
	{
		if(itemType == EquipableSlot.Weapon1 || itemType == EquipableSlot.Weapon2 || itemType == EquipableSlot.WeaponAll)
		{
			transform.parent = GameObject.FindGameObjectWithTag ("WeaponHandler").transform;
			transform.position = GameObject.FindGameObjectWithTag ("WeaponHandler").transform.position;
			transform.localScale = new Vector3 (.2f, .2f, .2f);
			transform.rotation = GameObject.FindGameObjectWithTag ("MainCamera").transform.rotation;
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			gameObject.GetComponent<Rigidbody> ().useGravity = false;
			equiped = true;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void SetVariables(object[] infoReceived)
	{
		itemName = infoReceived[0].ToString();
		itemRarity = (ItemRarity)infoReceived[1];
		itemLevel = (int)infoReceived[2];
		staminaValue = (int)infoReceived[3];
		secondaryStatValueName = (SecondaryStat)infoReceived [4];
		secondaryStatValue= (int)infoReceived[5];
		bonusValue1Name = (BonusStat)infoReceived [6];
		bonusValue1=(int)infoReceived[7];
		bonusValue2Name = (BonusStat)infoReceived [8];
		bonusValue2=(int)infoReceived[9];
		bonusValue3Name = (BonusStat)infoReceived [10];
		bonusValue3=(int)infoReceived[11];
		itemType = (EquipableSlot)infoReceived [12];
		requiredLevel = (int)infoReceived [13];
		minDamage = (int)infoReceived [14];
		maxDamage = (int)infoReceived [15];
		bonusAbility = infoReceived [16].ToString();
		itemID = infoReceived [17].ToString ();
		optionalBuffID = infoReceived [18].ToString ();
		armorValue = (int)infoReceived [19];
		equipCost = (int)infoReceived [20];	

		//itemType = infoReceived [12].ToString ();
	}
	public void HighlightItem()
	{
		if (GameObject.FindWithTag("ItemInfoCanvas")==null) {

			GameObject instantiateCanvas = (GameObject)Instantiate (interactionCanvas, transform.position, Quaternion.identity);
			instantiateCanvas.transform.Translate (0, 0.5f, 0);
			//instantiateCanvas.tag = "WID_0400Canvas";
			//instantiateCanvas.SendMessage ("SetVariables", ItemInfo());
			instantiateCanvas.SendMessage ("SetVariables", ItemInfo());
		}
	}
	public void PickUpItem()
	{
		int emptySlotID = InventoryManager.GetEmptySlot();
		if (emptySlotID != -1) {
			GameObject instantiateItem = (GameObject)Instantiate (itemObject, transform.position, Quaternion.identity);
			instantiateItem.transform.parent = InventoryManager.inventorySlots[emptySlotID].transform;
			instantiateItem.transform.position = InventoryManager.inventorySlots[emptySlotID].transform.position;
			instantiateItem.transform.localScale = new Vector3 (1f, 1f, 1f);
			instantiateItem.transform.gameObject.GetComponent<Image> ().sprite = icon;
			instantiateItem.SendMessage ("SetVariables", ItemInfo()); 
			instantiateItem.GetComponent<ItemInfoContainer> ().itemType = itemType;
			Destroy (this.gameObject);
		}
	}
	public object ItemInfo()
	{
		object[] tempStorage = new object[21];
		tempStorage [0] = itemName;
		tempStorage [1] = itemRarity;
		tempStorage [2] = itemLevel;
		tempStorage [3] = staminaValue;
		tempStorage [4] = secondaryStatValueName;
		tempStorage [5] = secondaryStatValue;
		tempStorage [6] = bonusValue1Name;
		tempStorage [7] = bonusValue1;
		tempStorage [8] = bonusValue2Name;
		tempStorage [9] = bonusValue2;
		tempStorage [10] = bonusValue3Name;
		tempStorage [11] = bonusValue3;
		tempStorage [12] = itemType;
		tempStorage [13] = requiredLevel;
		tempStorage [14] = minDamage;
		tempStorage [15] = maxDamage;
		tempStorage [16] = bonusAbility;
		tempStorage [17] = itemID;
		tempStorage [18] = optionalBuffID;
		tempStorage [19] = armorValue;
		tempStorage [20] = equipCost;
		return tempStorage;
	}
}
