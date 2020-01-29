/**
 * 
 * 	TEN SKRYPT TO STERUJE TARGETOWANIEM I PODNOSZENIEM ITEMÓW
 * 
 *  Input keys: Tab, E
**/

using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	RaycastHit hit;
	RaycastHit targetHit;
	RaycastHit lastTargetHit;
	public GameObject tag;
	public GameObject targetTag;

	void Update()
	{
		Debug.DrawRay (tag.transform.position, tag.transform.forward*3, Color.green);
		Debug.DrawRay (targetTag.transform.position, targetTag.transform.forward*50, Color.blue);
		if (Physics.Raycast (tag.transform.position, tag.transform.forward, out hit, 3.0f)) {
			if (hit.transform.gameObject.tag == "Item") {
				//hit.transform.gameObject.SendMessage ("PrepareDataToSend");
				hit.transform.gameObject.GetComponent<Item>().HighlightItem();
				hit.transform.gameObject.GetComponent<ItemPickUpHandler> ().itemTargeted = true;
			}else{
				Destroy(GameObject.FindGameObjectWithTag("ItemInfoCanvas"));
			}
		} else {
			Destroy(GameObject.FindGameObjectWithTag("ItemInfoCanvas"));
		}

		if (Input.GetKeyDown (KeyCode.Tab)) {
			GameObject[] toAllNPCs = GameObject.FindGameObjectsWithTag ("NPC");
			foreach (GameObject npc in toAllNPCs) {
				npc.SendMessage ("ClearTarget");
			}
			if (Physics.Raycast (targetTag.transform.position, targetTag.transform.forward, out targetHit, 50f)) {
				if (targetHit.transform.tag == "NPC") {
					targetHit.transform.GetComponent<NPCdata> ().SetTarget ();
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			if (Physics.Raycast (targetTag.transform.position, targetTag.transform.forward, out targetHit, 5f)) {
				if (targetHit.transform.tag == "Interactable" || targetHit.transform.tag == "NPC") {
					targetHit.transform.SendMessage ("Action");
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (Physics.Raycast (targetTag.transform.position, targetTag.transform.forward, out targetHit, 5f)) {
				if (targetHit.transform.tag == "Interactable" || targetHit.transform.tag == "NPC") {
					targetHit.transform.SendMessage ("Deny");
				}
			}
		}
	}
}
