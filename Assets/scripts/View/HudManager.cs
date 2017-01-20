using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HudManager  {
	public static HudManager instance=new HudManager();
	private GameObject hudParent;
	private GameObject canvas;

	private HudManager(){
		//hudParent = GameObject.Find ("View/Hud");
		canvas = GameObject.Find ("View/Hud");

	}

	public void LoadHud(EHudScreenID screenId){
        if (canvas.transform.childCount > 0)
        {
            GameObject  del= canvas.transform.GetChild(0).gameObject;
            GameObject.Destroy(del);
        }
        
        GameObject a=GameObject.Instantiate (Resources.Load ("Prefabs/"+screenId.ToString()) as GameObject);
		a.name = screenId.ToString ();
		a.transform.SetParent (canvas.transform);
       
        /*a.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        a.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        a.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        a.GetComponent<RectTransform>().localPosition =new Vector3(a.GetComponent<RectTransform>().localPosition.x, a.GetComponent<RectTransform>().localPosition.y,0);*/
    }
}
