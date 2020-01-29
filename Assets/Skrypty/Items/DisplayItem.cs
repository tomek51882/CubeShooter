using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayItem : MonoBehaviour {

	public Transform HUD;

	public Text itemName;
	public Text itemRarity;
	public Text itemLevel;
	public Text staminaValue;
	public Text secondaryStatValue;
	public Text bonusValue1;
	public Text bonusValue2;
	public Text bonusValue3;
	public Text requiredLevel;
	public Text damage;
	public Text bonusAbility;
	public Text armorValue;
	public Text equipCost;
	void Start()
	{
		transform.SetParent (GameObject.FindGameObjectWithTag ("HUDMain").transform);
		//		HUD = GameObject.FindGameObjectWithTag ("HUDMain").transform;
		//		transform.SetParent (HUD);
		//		transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
	}

	void Update () {
		transform.position = Input.mousePosition;
	}

	void SetVariables2(object[] infoReceived)
	{
		itemName.text = infoReceived[0].ToString();
		itemRarity.text = infoReceived[1].ToString();
		itemLevel.text = "Item level: " +infoReceived[2].ToString();
		staminaValue.text = "Stamina: " + infoReceived[3].ToString();
		secondaryStatValue.text = infoReceived[4].ToString() + ": " +infoReceived[5].ToString();
		if ((BonusStat)infoReceived [6] == BonusStat.None) {
			bonusValue1.text = "";
		} else {
			bonusValue1.text = infoReceived[6].ToString() + ": " +infoReceived[7].ToString();
		}
		if ((BonusStat)infoReceived [8] == BonusStat.None) {
			bonusValue2.text = "";
		} else {
			bonusValue2.text = infoReceived [8].ToString () + ": " + infoReceived [9].ToString ();
		}
		if ((BonusStat)infoReceived [10] == BonusStat.None) {
			bonusValue3.text = "";
		} else {
			bonusValue3.text = infoReceived[10].ToString() + ": " +infoReceived[11].ToString();
		}
		if (itemRarity.text == "Uncommon") {
			itemRarity.color = Color.green;
		}else if (itemRarity.text == "Rare") {
			itemRarity.color = Color.blue;
		}else if (itemRarity.text == "Epic") {
			itemRarity.color = Color.magenta;
		}else if (itemRarity.text == "Legendary") {
			itemRarity.color = Color.yellow;
		}
		itemRarity.text += " " + infoReceived [12].ToString();
		requiredLevel.text = "Required level: " +infoReceived [13].ToString ();
		if (infoReceived [14].ToString () == "0" && infoReceived [15].ToString () == "0") {
			damage.text = "";
		} else {
			damage.text = "Damage: "+ infoReceived [14].ToString () + " - " + infoReceived [15].ToString ();
		}

		bonusAbility.text = infoReceived [16].ToString ();
		armorValue.text = "Armor: " + infoReceived [19].ToString ();
		if (infoReceived [20].ToString () == "0") {
			equipCost.text = "";
		} else {
			equipCost.text = infoReceived [20].ToString ();
		}


	}
}