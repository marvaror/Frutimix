using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// Analysis disable CheckNamespace
public class objectdrag : MonoBehaviour ,IDragHandler,IBeginDragHandler,IEndDragHandler {
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;
    //public  GameObject [] clones;
    GameObject miClone;
    Sprite img;

    #region IBeginDragHandler implementation

    public void OnBeginDrag (PointerEventData eventData)
	{
        string auxmixer;
        string auxoutput;
        AudioClip auxaudioclip;
       
		//GameObject clon = Instantiate (clones [0], transform.position, transform.rotation)as GameObject;
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
        if (itemBeingDragged.GetComponent<PreEscuchar_Play>() != null)
        {
            auxmixer = itemBeingDragged.GetComponent<PreEscuchar_Play>().miMixer;
            auxoutput = itemBeingDragged.GetComponent<PreEscuchar_Play>().outPut;
            auxaudioclip=itemBeingDragged.GetComponent<PreEscuchar_Play>().miClip;
            miClone = GameObject.Instantiate(Resources.Load("Prefabs/sonidovacio" ) as GameObject);
            miClone.GetComponent<slotsound>().miMixer=auxmixer;
            miClone.GetComponent<slotsound>().outPut = auxoutput;
            miClone.GetComponent<slotsound>().miClip = auxaudioclip;
            img=itemBeingDragged.GetComponent<Image>().sprite;
            itemBeingDragged = miClone;
            Debug.Log("comenze a ser draggeado" + transform.parent.name);
        }
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
            miClone.GetComponent<Image>().sprite=img;
           
        }

        if (miClone.transform.parent == null)
        {
            Destroy(miClone);
        }
      
    }

	#endregion
}
