using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// Analysis disable CheckNamespace
public class objectdrag : MonoBehaviour ,IDragHandler,IBeginDragHandler,IEndDragHandler {
	public static GameObject itemBeingDragged;
    string namePrefab;
    Vector3 startPosition;

    //public  GameObject [] clones;
    GameObject miClone;
    Sprite img;
    GameObject slotOne;
    void Start()
    {
        slotOne = GameObject.Find("slot");
    }

    #region IBeginDragHandler implementation

    public void OnBeginDrag (PointerEventData eventData)
	{
        string auxmixer;
        string auxoutput;
        AudioClip auxaudioclip;
       
		//GameObject clon = Instantiate (clones [0], transform.position, transform.rotation)as GameObject;
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		//startParent =slotOne.transform;
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
            namePrefab = itemBeingDragged.name;
            img=itemBeingDragged.GetComponent<Image>().sprite;
            itemBeingDragged = miClone;
            itemBeingDragged.name = namePrefab;
            //Debug.Log("comenze a ser draggeado" + transform.parent.name);
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
        AudioClip c= Resources.Load("Audios/Arrastrar") as AudioClip;
        if ( miClone.transform.parent!=null){

                      
            miClone.GetComponent<Image>().sprite = img;
            miClone.transform.parent.GetComponent<AudioSource>().clip = c;
            miClone.transform.parent.GetComponent<AudioSource>().Play();
            


        }
        transform.position = startPosition;
        if (miClone.transform.parent == null)
        {
            Destroy(miClone);
        }
      
    }

	#endregion
}
