using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject draggedItem;
	public static Vector3 startPosition;
	public static Transform startParent;
	bool moved=false;

	public void OnBeginDrag (PointerEventData eventData)
	{
		draggedItem = gameObject;
		if (draggedItem.tag == "Item") {
			startPosition = transform.position;
			startParent = transform.parent;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
			if (!moved) {
				moved = true;
				transform.SetParent (GameObject.FindGameObjectWithTag ("HUDMain").transform);
			}
		} else {
			draggedItem = null;
		}
	}
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	public void OnEndDrag (PointerEventData eventData)
	{
		draggedItem = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent != startParent) {
			transform.position = startPosition;
		} else {
			//Destroy (gameObject);
			transform.position = startPosition;
		}
		transform.localScale = new Vector3 (1f, 1f, 1f);

	}
}
