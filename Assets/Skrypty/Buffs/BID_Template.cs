using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BID_Template : MonoBehaviour {

	bool buff = true; // false = debuff
	int duration;

	int bonusSTA;
	int bonusINT;
	int bonusAGI;
	int bonusSTR;
	int bonusSPR;
	int bonusVOI;

	int healPerSecond;
	int damagePerSecond;
	int bonusAbsorb;

	Image buffImage;
	int buffPosition=0;
	bool buffCasted =false;
	float timer=0.0f;
	float durationTimer=0.0f;

	float cooldown = 10f;
	float timerCooldown = 0.0f;
	bool castBlocked=false;


	void Update()
	{
		if (buffCasted) {
			//==================================================================================
			//timer jest uzywany do robienia "czegos" w "jakims" odstepie czasu, np doty/hoty
			//==================================================================================

			//timer += Time.deltaTime;
			//if (timer > [co_jaki_czas_ma_byc_tick]) {
			//	timer = 0.0f;
			//	[Do something...]
			//}

			//==================================================================================
			//durationTimer okresla dlugosc dzialania buffa
			//==================================================================================
			durationTimer += Time.deltaTime;

			if (durationTimer > duration) {
				DebuffEnded ();
			}
		}
		//==================================================================================
		//Cooldown
		//==================================================================================

		if (castBlocked == true) {
			timerCooldown += Time.deltaTime;
			if (timerCooldown > cooldown) {
				timerCooldown = 0f;
				castBlocked = false;
			}
		}
	}

	public void Cast(){
		//==================================================================================
		//Efekty ktore maja trwac przez czas dzialania buffa
		//==================================================================================

		//BazaDanych.bonusSTA += bonusHP;
	}

	public void DebuffEnded(){
		//==================================================================================
		//Zastap "Do something" jezeli ma sie cos zrobic po zakonczeniu buffa
		//==================================================================================

		//[Do something...]


		//==================================================================================
		//Usuniecie bonusow po zakonczeniu dzialania buffa
		//==================================================================================

		//BazaDanych.bonusSTA -= bonusHP;
	}

}
