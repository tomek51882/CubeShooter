using UnityEngine;
using System.Collections;

public class ItemPickUpHandler : MonoBehaviour {

	public bool itemTargeted = false;
	void Update()
	{
		if (GameObject.FindWithTag ("ItemInfoCanvas") == null) {
			itemTargeted = false;
		}

		if (Input.GetKey (KeyCode.F) && itemTargeted) {
			this.gameObject.SendMessage ("PickUpItem");
		}
	}


	bool GetItemTargetState()
	{
		return itemTargeted;
	}

}
