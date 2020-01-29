/**
 * 
 * 	TEN SKRYPT ZARZĄDZA WSZYSTKIMI WYŚWIETLANYMI ELEMENTAMI NA GŁÓWNEJ WARSTWIE HUD
 * 
 *  Input keys: C
**/

using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using System.Collections;

public class HudManager : MonoBehaviour {
	[Header("Gracz")]
	public Text hitPointsText;
	public Image hitPoitsBar;

	public Text manaPointsText;
	public Image manaPoitsBar;
	[Header("Panele")]
	public GameObject characterPanel;
	public GameObject questInfoPanel;
	[Header("Questy")]
	public Text questName;
	public Text questDesc;
	public Text questReward;
	public Text questObjective;
	[Header("Target")]
	public Text targetName;
	public Text targetStatText;
	public Image targetHitBar;
	public Image targetHitBarBG;
	[Header("Statystyki")]
	public Text staminaPoints;
	public Text bonusStaminaPoints;
	public Text staminaValue;

	public Text intellectPoints;
	public Text bonusIntellectPoints;
	public Text intellectValue;

	public Text agilityPoints;
	public Text bonusAgilityPoints;
	public Text agilityValue;
	public Text strengthPoints;
	public Text bonusStrengthPoints;
	public Text strengthValue;
	public Text spiritPoints;
	public Text bonusSpiritPoints;
	public Text spiritValue;
	public Text voidPoints;
	public Text bonusVoidPoints;
	public Text voidValue;
	public Text corPoints;
	public Text corValue;

	public Text statisticPointLeft;
	public Text attributePointLeft;

	public Text armorValue;
	public Text damageValue;
	public Text criticalChanceValue;
	public Text lifeSteal;
	public Text movementSpeed;
	[Header("Guziczki")]
	public GameObject staminaAddButton;
	public GameObject intellectAddButton;
	public GameObject agilityAddButton;
	public GameObject strengthAddButton;
	public GameObject spiritAddButton;

	bool showCharacterPanel = false;
	public GameObject gracz;

	void Start(){
		//usuniecie zagubionej owieczki ktora buguje caly system
		Destroy (GameObject.FindGameObjectWithTag ("ItemDesc"));
	}


	// Update is called once per frame
	void Update () {

		hitPoitsBar.fillAmount = BazaDanych.playerHitPoints / BazaDanych.playerMaxHitPoints;
		hitPointsText.text = BazaDanych.playerHitPoints.ToString() + "/" + BazaDanych.playerMaxHitPoints.ToString ();

		manaPoitsBar.fillAmount = BazaDanych.playerManaPoints / BazaDanych.playerMaxManaPoints;
		manaPointsText.text = BazaDanych.playerManaPoints.ToString() + "/" + BazaDanych.playerMaxManaPoints.ToString ();

		if (BazaDanych.showTarget) {
			targetName.text = BazaDanych.targetName;
			targetHitBar.fillAmount = BazaDanych.targetHitPoints / BazaDanych.targetMaxHitPoints;
			targetHitBarBG.enabled = true;
			targetStatText.text = BazaDanych.targetHitPoints.ToString () + "/" + BazaDanych.targetMaxHitPoints.ToString ();
		} else {
			targetName.text = "";
			targetHitBar.fillAmount = 0f;
			targetHitBarBG.enabled = false;
			targetStatText.text = "";
		}
		if (BazaDanych.showQuestInfo) {
			questInfoPanel.SetActive (true);
			questName.text = "Quest: " + BazaDanych.questName;
			questDesc.text = "Description: " + BazaDanych.questDescription;
			questReward.text = "Reward: " + BazaDanych.questReward;
			questObjective.text = "Objectives: " + BazaDanych.questObjective;


		} else {
			questInfoPanel.SetActive (false);
		}

		if (showCharacterPanel) {
			//------------------------------------------------------
			//WYSWIETLANIE STATYSTYK
			characterPanel.SetActive (true);
			staminaPoints.text = BazaDanych.sta.ToString ();
			bonusStaminaPoints.text = "+" + BazaDanych.bonusSTA.ToString ();
			staminaValue.text = "= " + BazaDanych.playerMaxHitPoints.ToString ();

			intellectPoints.text = BazaDanych.inte.ToString ();
			bonusIntellectPoints.text = "+" + BazaDanych.bonusINT.ToString ();
			intellectValue.text = "= " + BazaDanych.playerMaxManaPoints.ToString ();

			agilityPoints.text = BazaDanych.agi.ToString ();
			bonusAgilityPoints.text = "+" + BazaDanych.bonusAGI.ToString ();
			agilityValue.text = "= " + BazaDanych.playerAgi.ToString ();

			strengthPoints.text = BazaDanych.str.ToString ();
			bonusStrengthPoints.text = "+" + BazaDanych.bonusSTR.ToString ();
			strengthValue.text = "= " + BazaDanych.playerStr.ToString ();

			spiritPoints.text = BazaDanych.spr.ToString ();
			bonusSpiritPoints.text = "+" + BazaDanych.bonusSPR.ToString ();
			spiritValue.text = "= " + BazaDanych.playerSpr.ToString ();

			voidPoints.text = BazaDanych.voi.ToString ();
			bonusVoidPoints.text = "+" + BazaDanych.bonusVOI.ToString ();
			voidValue.text = "= " + BazaDanych.playerVoi.ToString ();

			corPoints.text = BazaDanych.cor.ToString ();
			corValue.text = "= " + BazaDanych.playerCor.ToString ();

			statisticPointLeft.text = "= " + BazaDanych.statisticsPoint.ToString ();
			attributePointLeft.text = "= " + BazaDanych.attributesPoint.ToString ();

			armorValue.text = "= " + BazaDanych.armorValue.ToString ();
			damageValue.text = "= " + BazaDanych.minDamageValue.ToString () + " - " + BazaDanych.maxDamageValue.ToString ();
			//criticalChanceValue.text = "= " + BazaDanych.
			//lifeSteal.text = "= " + 
			movementSpeed.text = "= " + BazaDanych.movementSpeed.ToString()+"%";


			//------------------------------------------------------
			//ZARZADZANIE PUNKTAMI
			if (BazaDanych.statisticsPoint > 0) {
				staminaAddButton.SetActive (true);
				intellectAddButton.SetActive (true);
				agilityAddButton.SetActive (true);
				strengthAddButton.SetActive (true);
				spiritAddButton.SetActive (true);

			} else {
				staminaAddButton.SetActive (false);
				intellectAddButton.SetActive (false);
				agilityAddButton.SetActive (false);
				strengthAddButton.SetActive (false);
				spiritAddButton.SetActive (false);

			}
		} else {
			characterPanel.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			showCharacterPanel = !showCharacterPanel;
			if (showCharacterPanel) {
				BazaDanych.showCursor++;
			} else {
				BazaDanych.showCursor--;
			}
		}

		if (BazaDanych.showCursor>0) {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			//GetComponent<MouseLook> ().XSensitivity = 0.0f;
		} else {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;


		}

//		if (Input.GetKey (KeyCode.LeftAlt)) {
//			Cursor.visible = true;
//			Cursor.lockState = CursorLockMode.None;
//			gracz.transform.gameObject.GetComponent<FirstPersonController>().enabled=false;
//		} else {
//			Cursor.visible = false;
//			Cursor.lockState = CursorLockMode.Locked;
//			gracz.transform.gameObject.GetComponent<FirstPersonController>().enabled=true;
//		}

	}


	public void AddStamina()
	{
		BazaDanych.sta++;
		BazaDanych.statisticsPoint--;
		BazaDanych.Refresh ();
	}
	public void AddIntellect()
	{
		BazaDanych.inte++;
		BazaDanych.statisticsPoint--;
		BazaDanych.Refresh ();
	}
	public void AddAgility()
	{
		BazaDanych.agi++;
		BazaDanych.statisticsPoint--;
		BazaDanych.Refresh ();
	}
	public void AddStrength()
	{
		BazaDanych.str++;
		BazaDanych.statisticsPoint--;
		BazaDanych.Refresh ();
	}
	public void AddSpirit()
	{
		BazaDanych.spr++;
		BazaDanych.statisticsPoint--;
		BazaDanych.Refresh ();
	}
}
