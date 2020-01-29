using UnityEngine;
using System.Collections;

public class SpellInstantiate : MonoBehaviour {

	public GameObject spell;

	public void Update()
	{
		if (transform.childCount == 0) {
			GameObject instantiateSpell = (GameObject)Instantiate (spell, transform.position, Quaternion.identity);
			instantiateSpell.transform.parent = gameObject.transform;
			instantiateSpell.transform.position = gameObject.transform.position;
			instantiateSpell.transform.localScale = new Vector3 (1f, 1f, 1f);
		}
	}

}
