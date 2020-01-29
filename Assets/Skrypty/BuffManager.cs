using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuffManager : MonoBehaviour {

	//tak NIE powinno sie robic, trzeba to zmienic w przyszlosci
	public GameObject[] _buffSlots;
	public static GameObject[] buffSlots;

	void Awake()
	{
		buffSlots = _buffSlots;
	}

	public static void RefreshPositions(){
		for (int i = 0; i < buffSlots.Length; i++) {
			if (buffSlots [i].transform.childCount == 0) {
				if (i + 1 < buffSlots.Length) {
					if (buffSlots [i + 1].transform.childCount > 0) {
						buffSlots [i + 1].transform.GetChild (0).parent = buffSlots [i].transform;						
					}
				}
			}
		}
	}
		
	public static int GetEmptySlot(){
		int emptyBuffSlotID=1;
		for (int i = 0; i < buffSlots.Length; i++) {
			if (buffSlots [i].transform.childCount == 0) {
				return i;
			}
		}

		return -1;
	}


}
