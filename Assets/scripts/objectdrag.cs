using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;



// Analysis disable CheckNamespace
public class objectdrag : MonoBehaviour ,IDragHandler,IBeginDragHandler,IEndDragHandler {
// Analysis restore CheckNamespace
	//public GameObject []baterias;

	/*public void OnClick(){
		GameObject clon = Instantiate (baterias [0], transform.position, transform .rotation)as GameObject;
	}*/

	//detectamos el primer click para mover objeto
	public void OnBeginDrag (PointerEventData eventdata){
		Debug.Log ("onbegindrag");

		this.transform.SetParent(this.transform.parent);
		//GameObject clon = Instantiate (baterias [0], transform.position, transform
		//	.rotation)as GameObject;
		
	}

	public void OnDrag (PointerEventData eventdata){
		Debug.Log ("ondrag");
		this.transform.position = eventdata.position;	

	}

	public void OnEndDrag (PointerEventData eventdata){
		Debug.Log ("onenddrag");

	}
}
