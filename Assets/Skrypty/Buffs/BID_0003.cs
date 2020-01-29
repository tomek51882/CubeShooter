using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BID_0003 : MonoBehaviour {

	public void DebuffStarted(){
	}

	public void DebuffActive(){
	}

	public void DebuffEnded(){
		BuffManager.RefreshPositions ();
		Destroy (gameObject);
	}

}
