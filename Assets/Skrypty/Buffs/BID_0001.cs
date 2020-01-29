using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BID_0001 : MonoBehaviour {

	//==================================================================
	//	BID_0001 - Debuff typu damage-over-time
	//
	//	castwowany przez:
	//	SID_0002
	//==================================================================

	int duration =8;
	int damagePerSecond=5;
	float timer=0.0f;
	float durationTimer=0.0f;

	void Start()
	{
		DebuffStarted ();
	}

	void Update()
	{
		DebuffActive ();
	}


	public void DebuffStarted(){
	}

	public void DebuffActive(){
		timer += Time.deltaTime;
		durationTimer += Time.deltaTime;
		if (timer > 1) {
			timer = 0.0f;
			BazaDanych.playerHitPoints = BazaDanych.playerHitPoints - damagePerSecond;
		}
		if (durationTimer > duration) {
			transform.parent = null;
			DebuffEnded ();
		}
	}

	public void DebuffEnded(){
		BuffManager.RefreshPositions ();
		Destroy (gameObject);
	}

}
