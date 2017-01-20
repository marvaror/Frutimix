using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSplash : MonoBehaviour {
    GameObject mychild;
	// Use this for initialization
	void Awake () {
        //if (mychild == null)
        {
            mychild = transform.GetChild(0).gameObject;
            mychild.GetComponent<Button>().onClick.AddListener(() => OnClickB()); 
           
        }

       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClickB()
    {
        HudManager.instance.LoadHud(EHudScreenID.MenuInicio);
        Debug.Log("asda");
    }
}
