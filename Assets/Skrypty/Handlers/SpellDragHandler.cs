using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SpellDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject draggedItem;
	Vector3 startPosition;
	Transform startParent;
	bool moved=false;
	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		draggedItem = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		if (!moved) {
			moved = true;
			transform.SetParent (GameObject.FindGameObjectWithTag ("HUDMain").transform);
		}
	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		draggedItem = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent != startParent) {
			transform.position = startPosition;
		} else {
			Destroy (gameObject);
		}

	}

	#endregion
}
