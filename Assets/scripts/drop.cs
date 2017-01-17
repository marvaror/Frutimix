using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Analysis disable CheckNamespace




public class drop : MonoBehaviour, IDropHandler,IPointerExitHandler,IPointerEnterHandler {

	public void OnPointerEnter(PointerEventData eventdata){

		Debug.Log ("pointer enter " + gameObject.name);
	}

	public void OnPointerExit(PointerEventData eventdata){

		Debug.Log ("pointer exit " + gameObject.name);
	}

	public void OnDrop(PointerEventData eventdata){

		Debug.Log ("ondrop to " + gameObject.name);
	}

}

