using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SpellbookManager : MonoBehaviour {

	public GameObject spellDescription;
	public GameObject spellBook;
	bool showSpellbook = false;

	public void ShowDescription()
	{
		Instantiate (spellDescription, Input.mousePosition, Quaternion.identity);
	}
	public void HideDescription()
	{
		Destroy (GameObject.FindGameObjectWithTag ("spellDesc"));
	}
	void Start(){
		if (showSpellbook) {
			spellBook.SetActive (true);
		} else {
			spellBook.SetActive (false);
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.V)) {
			showSpellbook = !showSpellbook;
			if (showSpellbook) {
				spellBook.SetActive (true);
				BazaDanych.showCursor++;
			} else {
				spellBook.SetActive (false);
				Destroy (GameObject.FindGameObjectWithTag ("spellDesc"));
				BazaDanych.showCursor--;
			}
		}
	}
}
