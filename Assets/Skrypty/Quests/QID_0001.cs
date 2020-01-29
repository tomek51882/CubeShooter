using UnityEngine;
using System.Collections;

public class QID_0001 : MonoBehaviour {

	//==================================================================
	//	TODO:
	//	Jakis tam badziewny quest
	//  QuestManager?????
	//
	//==================================================================

	public string questName;
	public string questDescription;
	public string questObjective;
	public string questReward;
	bool canTakeQuest=true;
	public int xpReward;

	public void Action()
	{
		if (canTakeQuest) {
			if (!BazaDanych.showQuestInfo) {
				ShowQuest ();
			} else {
				AcceptQuest ();

			}
		}
	}
	public void Deny()
	{
		if (canTakeQuest) {
			if (BazaDanych.showQuestInfo) {
				DenyQuest ();
			}
		}
	}
	public void ShowQuest(){
		BazaDanych.questName = questName;
		BazaDanych.questDescription = questDescription;
		BazaDanych.questObjective = questObjective;
		BazaDanych.questReward = questReward;
		BazaDanych.showQuestInfo = true;
	}
	public void HideQuest()
	{
		BazaDanych.showQuestInfo = false;
	}
	public void AcceptQuest(){
		Debug.Log("QuestAccepted");
		BazaDanych.showQuestInfo = false;
		BazaDanych.questAccepted = true;
		canTakeQuest = false;
	}
	public void DenyQuest(){
		Debug.Log("QuestDenied");
		BazaDanych.showQuestInfo = false;
		canTakeQuest = true;
	}
	public void ActiveQuest(){
	}
	public void FailedQuest(){
	}
	public void AbandonQuest(){
	}
}
