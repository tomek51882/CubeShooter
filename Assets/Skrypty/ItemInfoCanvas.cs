/**
 * 
 * 	TEN SKRYPT POKAZUJE STATYSTKI PRZEDMIOTU PO SPOJRZENIU SIĘ NA NIEGO ALE PRZED JEGO PODNIESIENIEM
 * 
 * 
**/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemInfoCanvas : MonoBehaviour {

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
	public Color color;
	public Text armorValue;
	public Text equipCost;

	Vector3 Kierunek;
	Quaternion obrot;
	GameObject Gracz;

	void SetVariables(object[] infoReceived)
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
			itemRarity.color = color;
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
	void Start()
	{
		Gracz = GameObject.FindGameObjectWithTag ("MainCamera");
		Kierunek = Gracz.transform.position - transform.position;
		Kierunek.Normalize ();
		Debug.DrawLine (Gracz.transform.position, transform.position, Color.red);

		obrot = Quaternion.LookRotation (Kierunek);
		transform.rotation = obrot;
	}
	void Update()
	{
		Kierunek = Gracz.transform.position - transform.position;
		Kierunek.Normalize ();
		Debug.DrawLine (Gracz.transform.position, transform.position, Color.red);

		obrot = Quaternion.LookRotation (Kierunek);
		transform.rotation = obrot;
	}
}
