using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Reproducir_Pista : MonoBehaviour {

	AudioSource pista;

	// Use this for initialization
	void Start () {
		pista = transform.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	public void EscucharPista() {

		pista.Stop ();
		AudioClip sonido = Resources.Load("Audios/Beat_2") as AudioClip;
		AudioMixer mixer = Resources.Load("Mixers/Nivel2") as AudioMixer;
		pista.outputAudioMixerGroup = mixer.FindMatchingGroups ("Elec_2") [0];
		pista.clip = sonido;
		pista.Play ();

	}
}
