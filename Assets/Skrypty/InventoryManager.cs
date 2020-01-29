using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	//tak NIE powinno sie robic, trzeba to zmienic w przyszlosci
	public GameObject panel;
	public GameObject[] _inventorySlots;
	public static GameObject[] inventorySlots;
	float licznik = 0;
	int slot=0;
	Color test;
	bool showInventory = false;

	void Awake()
	{
		inventorySlots = _inventorySlots;
		test = inventorySlots [0].GetComponent<Image> ().color;
		panel.transform.localScale = new Vector3 (0, 0.66f, 0.66f);
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.B)) {
			showInventory = !showInventory;
			if (showInventory) {
				BazaDanych.showCursor++;
				panel.transform.localScale = new Vector3 (0.66f, 0.66f, 0.66f);
			} else {
				BazaDanych.showCursor--;
				panel.transform.localScale = new Vector3 (0, 0.66f, 0.66f);
				Destroy (GameObject.FindGameObjectWithTag ("ItemDesc"));
			}
		}
	}

	public static void RefreshPositions(){
		for (int i = 0; i < inventorySlots.Length; i++) {
			if (inventorySlots [i].transform.childCount == 0) {
				if (i + 1 < inventorySlots.Length) {
					if (inventorySlots [i + 1].transform.childCount > 0) {
						inventorySlots [i + 1].transform.GetChild (0).parent = inventorySlots [i].transform;						
					}
				}
			}
		}
	}

	public static int GetEmptySlot(){
		int emptyBuffSlotID=1;
		for (int i = 0; i < inventorySlots.Length; i++) {
			if (inventorySlots [i].transform.childCount == 0) {
				return i;
			}
		}

		return -1;
	}

//	void Update()
//	{
//		licznik += Time.deltaTime;
//
//		if (licznik > 0.1f) {
//			licznik = 0f;
//
//			if (slot == 32) {
//				slot = 0;
//			}
//			if (slot != 0 && slot !=31) {
//				inventoryStots [slot].GetComponent<Image> ().color = Color.red;
//				inventoryStots [slot - 1].GetComponent<Image> ().color = color;
//			} else if (slot == 0) {
//				inventoryStots [slot].GetComponent<Image> ().color = Color.red;
//				inventoryStots [31].GetComponent<Image> ().color = test;
//			} else if (slot == 31) {
//				inventoryStots [slot].GetComponent<Image> ().color = Color.red;
//				inventoryStots [slot - 1].GetComponent<Image> ().color = test;
//			}
//			Debug.Log (slot);
//
//			slot++;
//
//		}
//	}
}
