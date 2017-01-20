using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;



// Analysis disable CheckNamespace
public class objectdrag : MonoBehaviour ,IDragHandler,IBeginDragHandler,IEndDragHandler {
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;
	//public GameObject []baterias;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		//GameObject clon = Instantiate (baterias [0], rectransform.position, rectransform.rotation)as GameObject;
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = eventData.position;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if(transform.parent == startParent){
			transform.position = startPosition;
		}
	}

	#endregion
}
