using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// Cargamos los prefabs principales
	    HudManager.instance.LoadHud (EHudScreenID.MenuInicio);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
