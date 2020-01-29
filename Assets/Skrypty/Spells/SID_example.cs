using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SID_example : MonoBehaviour {

	//==================================================================
	//	SID_0001 - Czyli tak zwany "Fireball" z gównianą grafiką
	//==================================================================
	[Header("Ustawienia spella")]
	public int spellCost;
	public string spellName;
	public string spellDesc;

	public float cooldown = 10;
	public float cooldownTimer;
	public Image cooldownImage;
	bool casted = false;

	public int minDamage;
	public int maxDamage;

	public float damageBonus;
	public float criticalChance;

	public GameObject spell;

	public void Update()
	{
		if (cooldownTimer == 0f && casted) {
			//==================================================================================
			//Tutaj idzie efekt spella
			//==================================================================================
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
		GameObject[] allSpellClones = GameObject.FindGameObjectsWithTag ("SIDexample");
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