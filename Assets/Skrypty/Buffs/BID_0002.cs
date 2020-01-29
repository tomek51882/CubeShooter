using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BID_0002 : MonoBehaviour {

	int duration =5;
	int healPerSecond=7;
	float timer=0.0f;
	float durationTimer=0.0f;

	void Update()
	{
		timer += Time.deltaTime;
		durationTimer += Time.deltaTime;
		if (timer > 1) {
			timer = 0.0f;
			BazaDanych.playerHitPoints += healPerSecond;
		}
		if (durationTimer > duration) {
			DebuffEnded ();
		}
	}
	public void DebuffEnded(){
		transform.parent = null;
		BuffManager.RefreshPositions ();
		Destroy (gameObject);
	}
}
