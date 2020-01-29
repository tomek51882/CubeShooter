using UnityEngine;
using System.Collections;

public class SpellSlot1Handler : MonoBehaviour {

	void Update () {
		if (Input.GetKey (KeyCode.Alpha1)) {
			transform.GetChild(0).SendMessage ("Cast");
		}
	}
}
