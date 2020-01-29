/**
 * 
 * 	TEN SKRYPT STERUJE PASKIEM ŻYCIA WYŚWIETLONYM NAD PRZECIWNIKIEM
 * 
 * 
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHighlight : MonoBehaviour {
	
	public Text NPCName;
	public Image NPCHitBar;
	public Image NPCHitBarBG;
	public float hp;
	public float maxhp;
	Vector3 Kierunek;
	Quaternion obrot;
	GameObject Gracz;

	void Update()
	{
		NPCHitBar.fillAmount = hp / maxhp;

		Gracz = GameObject.FindGameObjectWithTag ("MainCamera");
		Kierunek = Gracz.transform.position - transform.position;
		Kierunek.Normalize ();
		Debug.DrawLine (Gracz.transform.position, transform.position, Color.red);

		obrot = Quaternion.LookRotation (-Kierunek);
		transform.rotation = obrot;
	}
}
