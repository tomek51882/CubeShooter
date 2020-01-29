using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ItemInventotySlot : MonoBehaviour, IDropHandler  {
	/*
	 * Sloty na itemy do zalozenia
	 * 
	 */

	public GameObject itemDescription;
	public static GameObject draggedItem;
	Vector3 startPosition;
	Transform startParent;
	bool moved=false;

	public EquipableSlot slot;

	#region DRAG & DROP IMPLEMENTATION START HERE
	public GameObject item {
		get {
			if(transform.childCount>0){
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}
		
	public void OnDrop (PointerEventData eventData)
	{
		if (!item) {	
			if (ItemDragHandler.draggedItem.gameObject.GetComponent<ItemInfoContainer> ().itemType == slot) { //czy upuszczany item pasuje do slota
				ItemDragHandler.draggedItem.transform.SetParent (transform);
				transform.GetChild (0).gameObject.SendMessage ("SlotChanged");
			}
		}
	}
	#endregion


	public void ShowItemDescription()
	{
		if (gameObject.transform.childCount > 0) {
			GameObject desc = (GameObject)Instantiate (itemDescription, Input.mousePosition, Quaternion.identity);
			desc.SendMessage ("SetVariables2", CreateObjectWithData());
		}
	}
	public void HideItemDescription()
	{
		Destroy (GameObject.FindGameObjectWithTag ("ItemDesc"));
		Destroy (GameObject.FindGameObjectWithTag ("ItemDesc"));
	}

	public object CreateObjectWithData()
	{
		object[] tempStorage = new object[21];
		tempStorage [0] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().itemName;
		tempStorage [1] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().itemRarity;
		tempStorage [2] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().itemLevel;
		tempStorage [3] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().staminaValue;
		tempStorage [4] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().secondaryStatValueName;
		tempStorage [5] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().secondaryStatValue;
		tempStorage [6] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().bonusValue1Name;
		tempStorage [7] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().bonusValue1;
		tempStorage [8] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().bonusValue2Name;
		tempStorage [9] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().bonusValue2;
		tempStorage [10] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().bonusValue3Name;
		tempStorage [11] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().bonusValue3;
		tempStorage [12] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().itemType;
		tempStorage [13] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().requiredLevel;
		tempStorage [14] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().minDamage;
		tempStorage [15] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().maxDamage;
		tempStorage [16] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().bonusAbility;
		tempStorage [17] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().itemID;
		tempStorage [18] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer>().optionalBuffID;
		tempStorage [19] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer> ().armorValue;
		tempStorage [20] = gameObject.transform.GetChild (0).GetComponent<ItemInfoContainer> ().equipCost;
		return tempStorage;

	}
}
