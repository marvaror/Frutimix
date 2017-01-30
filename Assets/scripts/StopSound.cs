using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class StopSound : MonoBehaviour {
    GameObject muestra;
    GameObject hand;
    GameObject zonaColocacion;
    int numChildren;
    // Use this for initialization
    void Start () {
        muestra = GameObject.Find("Muestra");
        zonaColocacion = GameObject.Find("zonacolocacion");
        hand = GameObject.Find("hand");
        numChildren = zonaColocacion.transform.childCount;
    }
	
	public void StopEveryThing()
    {
        hand.GetComponent<AudioSource>().Stop();
        muestra.GetComponent<AudioSource>().Stop();
        for (int i = 0; i < numChildren; ++i)
        {
            zonaColocacion.transform.GetChild(i).GetComponent<AudioSource>().Stop();
        }
    }
}
