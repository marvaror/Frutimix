using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Reproducir_Pista : MonoBehaviour {

	AudioSource pista;
    List<string> actualList;
	GameObject muestraManager; 
	GameObject hand; 
	// Use this for initialization
	void Start () {
		pista = transform.GetComponent<AudioSource> ();
		muestraManager = GameObject.Find ("zonacolocacion");
		hand = GameObject.Find ("hand");

	}
	
	// Update is called once per frame
	public void EscucharPista() {

		hand.GetComponent<AudioSource>().Stop();

		pista.Stop ();
        ReadJson f;
        f = muestraManager.GetComponent<ReadJson>();
        int actualLevel = f.level;
        actualList = f.MyList();
        if (actualList.Count>0)
        {
			Debug.Log("entre");
            AudioClip sonido = Resources.Load("Audios/" + actualList[0]) as AudioClip;
            AudioMixer mixer = Resources.Load("Mixers/" + actualList[1]) as AudioMixer;
            pista.outputAudioMixerGroup = mixer.FindMatchingGroups(actualList[2])[0];
            pista.clip = sonido;
            pista.Play();
        }
        else
        {
            Debug.LogError("La lista esta vacia, analizar json");
        }

	}
}
