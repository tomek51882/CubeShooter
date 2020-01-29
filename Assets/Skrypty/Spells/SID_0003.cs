using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SID_0003 : MonoBehaviour {

	//==================================================================
	//	SID_0001 - Czyli tak zwany "Fireball" z gównianą grafiką
	//==================================================================
	[Header("Ustawienia spella")]
	public int spellCost;
	public string spellName;
	public string spellDesc;

	public float cooldown = 5;
	public float cooldownTimer;
	public Image cooldownImage;
	bool casted = false;

	public int minDamage;
	public int maxDamage;

	public float damageBonus;
	public float criticalChance;

	public GameObject buff;
	int emptyBuffSlotID;

	public void Update()
	{
		if (cooldownTimer == 0f && casted) {
			//==================================================================================
			//Tutaj idzie efekt spella
			//==================================================================================
			emptyBuffSlotID = BuffManager.GetEmptySlot();
			if (emptyBuffSlotID != -1) {
				GameObject instantiateSpell = (GameObject)Instantiate (buff, transform.position, Quaternion.identity);
				instantiateSpell.transform.parent = BuffManager.buffSlots[emptyBuffSlotID].transform;
				instantiateSpell.transform.position = BuffManager.buffSlots[emptyBuffSlotID].transform.position;
				instantiateSpell.transform.localScale = new Vector3 (1f, 1f, 1f);
			}
		}

		if (casted) {
			cooldownTimer += Time.deltaTime;
			cooldownImage.fillAmount = (cooldown - cooldownTimer) / cooldown;
			if (cooldownTimer > cooldown) {
				casted = false;
				cooldownTimer = 0f;
				cooldownImage.fillAmount = 0f;
			}
		}
	}

	public void Cast()
	{
		GameObject[] allSpellClones = GameObject.FindGameObjectsWithTag ("SID0003");
		foreach (GameObject element in allSpellClones) {
			element.SendMessage ("CastWithoutEffect");
		}


	}
	public void CastWithoutEffect()
	{
		casted = true;
	}

	public void SetSpellInfo()
	{
		BazaDanych.spellName = spellName;
		BazaDanych.spellCost = spellCost;
		BazaDanych.spellDesc = spellDesc;
	}
}