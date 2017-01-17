using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;



// Analysis disable CheckNamespace
public class objectdrag : MonoBehaviour ,IDragHandler,IBeginDragHandler,IEndDragHandler {
// Analysis restore CheckNamespace
	
	//detectamos el primer click para mover objeto
	public void OnBeginDrag (PointerEventData eventdata){
		Debug.Log ("onbegindrag");
		
	}

	public void OnDrag (PointerEventData eventdata){
		Debug.Log ("ondrag");
		this.transform.position = eventdata.position;	

	}

	public void OnEndDrag (PointerEventData eventdata){
		Debug.Log ("onenddrag");

	}
}
