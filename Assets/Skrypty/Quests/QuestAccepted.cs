using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestAccepted : MonoBehaviour {

	public GameObject newQuestCanvas;
	public GameObject questNameCanvas;
	public GameObject text1Place;
	public GameObject text2Place;
	public Text questName;
	public Text newQuest;
	public Color fadeIn;
	public Color fadeOut;
	Vector3 newQuestPos;
	Vector3 questNamePos;

	float timer = 0f;
	public float duration = 3f;
	float colorChange=0;

	void Start()
	{
		questName.color = fadeIn;
		newQuest.color = fadeIn;
	}

	void Update()
	{
		if (timer < duration && BazaDanych.questAccepted) {
			questName.text = BazaDanych.questName;
			if (timer < 2) {
				if (colorChange < 1) {
					questName.color = Color.Lerp (fadeIn, fadeOut, colorChange);
					newQuest.color = Color.Lerp (fadeIn, fadeOut, colorChange);
					colorChange += 0.01f;
				}
			}
			if (timer > 4) {
				if (colorChange >= 0) {
					questName.color = Color.Lerp (fadeIn, fadeOut, colorChange);
					newQuest.color = Color.Lerp (fadeIn, fadeOut, colorChange);
					colorChange -= 0.01f;
				}
			}
			newQuestCanvas.transform.Translate (.25f, 0, 0);
			questNameCanvas.transform.Translate (.35f, 0, 0);
			timer += Time.deltaTime;
		} else {
			if (BazaDanych.questAccepted) {
				questName.color = fadeIn;
				newQuest.color = fadeIn;
				timer = 0f;
				BazaDanych.questAccepted = false;
				newQuestCanvas.transform.position = text1Place.transform.position;
				questNameCanvas.transform.position = text2Place.transform.position;
			}
		}
	}
}
