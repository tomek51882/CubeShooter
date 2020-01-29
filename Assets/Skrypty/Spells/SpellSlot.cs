using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SpellSlot : MonoBehaviour, IDropHandler {

	public GameObject item {
		get {
			if(transform.childCount>0){
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}
	public void OnDrop (PointerEventData eventData)
	{
		if (!item) {
			SpellDragHandler.draggedItem.transform.SetParent (transform);
		}
	}
}
