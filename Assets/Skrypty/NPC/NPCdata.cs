/**
 * 
 * 	TEN SKRYPT MUSI BYĆ W KAŻDYM NPC. STERUJE ON ŻYCIEM ORAZ INNYMI STATYSTYKAMI
 *  NPCA W TYM JEGO AGGRO ORAZ SWOIM PASKIEM ZYCIA
 * 
**/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCstatus{
	Friendly,Neutral,Hostile,Dead
}
public class NPCdata : MonoBehaviour {

	public GameObject targetHighlight;
	public GameObject highlightPlace;
	GameObject targetHighlightActive;

	public NPCstatus status;
	public string NPCname;
	public int health;
	public int lastHealth;
	public int maxHealth;
	public int armor;
	public bool aggro = false;
	public int aggroTime = 0;
	public bool targeted = false;
	public float aggroTimer=0;
	NavMeshAgent agent ;
	GameObject cel;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		cel = GameObject.FindGameObjectWithTag ("Gracz");

	}

	void Update()
	{
		if (targetHighlightActive != null) {
			targetHighlightActive.transform.position = highlightPlace.transform.position;
		}
		if (aggro && status!=NPCstatus.Dead) {
			agent.destination = cel.transform.position;
			agent.isStopped = false;
			aggroTimer += Time.deltaTime;

			if (aggroTimer > aggroTime) {
				
				OnAggroLost ();
			}
		}

	}
	void GetAggro()
	{
		
		if (!aggro) {
			aggro = true;
		}
	}
	void OnAggroLost()
	{
		aggro = false;
		aggroTimer = 0;
		Debug.Log ("Aggro lost");
		agent.isStopped = true;
		if (status != NPCstatus.Dead) {
			health = maxHealth;
			targetHighlightActive.transform.GetComponent<NPCHighlight> ().hp = health;
			targetHighlightActive.transform.GetComponent<NPCHighlight> ().maxhp = maxHealth;
			UpdateStatus ();
		}
	}

	void OnDeath()
	{
		transform.GetComponent<Rigidbody> ().isKinematic = false;

	}

	void Action()
	{
		
	}
	void Deny()
	{

	}
		
	public void SetTarget()
	{
		if (!targeted) {
			BazaDanych.showTarget = true;
			targeted = true;
		}
		UpdateStatus ();
	}

	public void ClearTarget()
	{
		targeted = false;
		BazaDanych.showTarget = false;

		UpdateStatus ();
	}
	public void UpdateStatus()
	{	
		if (targeted) {
			BazaDanych.targetHitPoints = health;
			BazaDanych.targetMaxHitPoints = maxHealth;
			BazaDanych.targetArmorPoints = armor;
			BazaDanych.targetName = NPCname;
			if (targetHighlightActive == null) {
				targetHighlightActive = Instantiate(targetHighlight, transform.position, Quaternion.identity);
				targetHighlightActive.transform.position = highlightPlace.transform.position;
				targetHighlightActive.transform.GetComponent<NPCHighlight> ().NPCName.text = NPCname.ToString ();
				targetHighlightActive.transform.GetComponent<NPCHighlight> ().hp = health;
				targetHighlightActive.transform.GetComponent<NPCHighlight> ().maxhp = maxHealth;
			}
			switch (status) {
				case NPCstatus.Friendly:
				{
					targetHighlightActive.transform.GetComponent<NPCHighlight> ().NPCHitBar.color = BazaDanych.friendlyHealthColorTarget;
					break;
				}
				case NPCstatus.Neutral:
				{
					targetHighlightActive.transform.GetComponent<NPCHighlight> ().NPCHitBar.color = BazaDanych.neutralHealthColorTarget;
					break;
				}
				case NPCstatus.Hostile:
				{
					targetHighlightActive.transform.GetComponent<NPCHighlight> ().NPCHitBar.color = BazaDanych.hostileHealthColorTarget;
					break;
				}
				case NPCstatus.Dead: 
				{
					break;
				}
			}
			targetHighlightActive.transform.localScale = new Vector3 (2f, 2f, 2f);
		} else {
			if (targetHighlightActive != null) {
				targetHighlightActive.transform.localScale = new Vector3 (1f, 1f, 1f);
			}

		}

		if (health == maxHealth) {
			if (!targeted) {
				Destroy (targetHighlightActive);
				targetHighlightActive = null;
			}
		}
		if (health < maxHealth && health > 0) {
			if (lastHealth != health) {
				aggroTimer = 0;
				lastHealth = health;
			}
			if (targetHighlightActive == null) {
				targetHighlightActive = Instantiate (targetHighlight, transform.position, Quaternion.identity);
				targetHighlightActive.transform.position = highlightPlace.transform.position;
			}
			if (targeted) {
				
			}
			targetHighlightActive.transform.GetComponent<NPCHighlight> ().NPCName.text = NPCname.ToString ();
			targetHighlightActive.transform.GetComponent<NPCHighlight> ().hp = health;
			targetHighlightActive.transform.GetComponent<NPCHighlight> ().maxhp = maxHealth;

			if (!targeted) {
				switch (status) {
				case NPCstatus.Friendly:
					{
						targetHighlightActive.transform.GetComponent<NPCHighlight> ().NPCHitBar.color = BazaDanych.friendlyHealthColor;
						break;
					}
				case NPCstatus.Neutral:
					{
						targetHighlightActive.transform.GetComponent<NPCHighlight> ().NPCHitBar.color = BazaDanych.neutralHealthColor;
						break;
					}
				case NPCstatus.Hostile:
					{
						targetHighlightActive.transform.GetComponent<NPCHighlight> ().NPCHitBar.color = BazaDanych.hostileHealthColor;
						break;
					}
				case NPCstatus.Dead: 
					{
						break;
					}
				}
				targetHighlightActive.transform.GetComponent<NPCHighlight> ().NPCName.color = BazaDanych.textColor;
			}
		} else if(!targeted){
			Destroy (targetHighlightActive);
			targetHighlightActive = null;
		}

		if (health <= 0) {
			if (status != NPCstatus.Dead) {
				status = NPCstatus.Dead;
				NPCname += " [Dead]";
				if (targeted) {
					BazaDanych.showTarget = false;
					targeted = false;
				}
				aggro=false;
				aggroTimer = 0f;
				OnDeath ();
			}
			health = 0;
			if(!targeted){
				Destroy (targetHighlightActive);
				targetHighlightActive = null;
			}
		}
	}
}
	

