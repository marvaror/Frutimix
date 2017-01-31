using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addcamera : MonoBehaviour {
    GameObject micamera;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        gameObject.GetComponent<Canvas>().worldCamera = Camera.main; //  micamera.GetComponent<Camera>();
        //Debug.Log(gameObject.GetComponent<Canvas>().camera);
        Debug.Log(gameObject.GetComponent<Canvas>().worldCamera);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
