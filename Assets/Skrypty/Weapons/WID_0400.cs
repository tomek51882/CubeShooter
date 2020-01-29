/**
 * 
 * 	TEN SKRYPT TO SKRYPT BRONI. ZDAJDUJE SIĘ ON W ITEMIE. STERUJE ON 
 *  STRZELANIEM ORAZ INICJUJE IKONE W EKWIPUNKU GDY PODNIESIONY Z ZIEMI
 * 	BAZA DO GENEROWANIA ITEMÓW
 * 
 *  Input keys: Mouse0
**/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
	
public class WID_0400 : MonoBehaviour {

	#region TODO
	/*
	 * Trzeba wymyslic sposob aby odpalic unikatowy efekt przedmiotu jezeli on wystepuje
	 * 
	 * Rozwiązania:
	 * 	- #1.1 Stworzyc skrypt z efektem, AddComponent<Skrypt>() do ikonki i odpalac przez SendMessage()?
	 *  - #1.2 Lepiej myśleć [to wygrało]
	 * 
	 * 	- Problem sam się rozwiązał
	 * */
	#endregion
	
	public Sprite icon;
	public GameObject itemObject;
	public SphereCollider interactionCollider;
	public bool equiped=false;
	public string itemID;
	public string optionalBuffID; //buff gdy broń jest wyposażona
	public GameObject wylot;

	public int minDamage;
	public int maxDamage;

	RaycastHit hit;
	void Start()
	{
		minDamage = GetComponent<Item>().minDamage;
		maxDamage = GetComponent<Item>().maxDamage;
		equiped = GetComponent<Item> ().equiped;
	}

	void Update()
	{
		if (equiped) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				if (Physics.Raycast (wylot.transform.position, wylot.transform.forward, out hit, 100f)) {
					if (hit.transform.tag == "NPC") {
						hit.transform.GetComponent<NPCdata> ().aggro = true;
						hit.transform.GetComponent<NPCdata> ().health -= Random.Range (minDamage, maxDamage);
						hit.transform.GetComponent<NPCdata> ().UpdateStatus ();
					}
				}
			}
		}
		Debug.DrawRay(wylot.transform.position, wylot.transform.forward*100,Color.red);
	}
}
