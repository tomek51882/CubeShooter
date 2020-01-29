using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellDescription : MonoBehaviour {

	public Transform HUD;
	public Text name;
	public Text manaCost;
	public Text desc;
	public GameObject spellDescription;
	// Use this for initialization
	#region REWORK HERE -> ItemDescription.cs
	void Start () {
		
		HUD = GameObject.FindGameObjectWithTag ("HUDMain").transform;
		transform.SetParent (HUD);

		name.text = BazaDanych.spellName;
		manaCost.text = BazaDanych.spellCost.ToString () + " Mana";
		desc.text = BazaDanych.spellDesc;

		transform.localScale = new Vector3 (1f, 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Input.mousePosition;
	}
	
	public void ShowSpellDescription()
	{
		if (gameObject.transform.childCount > 0) {
			GameObject _desc = (GameObject)Instantiate (spellDescription, Input.mousePosition, Quaternion.identity);
			desc.SendMessage ("SetVariables2", CreateObjectWithData());
		}
	}
	public void HideSpellDescription()
	{
	}
	
	public object CreateObjectWithData()
	{
		object[] data = new object[2];
		
		data[0] = name.text;
		data[1] = manaCost.text;
		data[2] = desc.text;
		
		return data;
		
	}

	#endregion
		
}
