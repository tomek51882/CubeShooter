using UnityEngine;
using System.Collections;

public class SpellSlot2Handler : MonoBehaviour {
	
	void Update () {
		if (Input.GetKey (KeyCode.Alpha2)) {
			transform.GetChild(0).SendMessage ("Cast");
		}

	}
}
