using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PreEscuchar_Play : MonoBehaviour {

	AudioSource sound;
	public string miMixer;
    public string outPut;
    public AudioClip miClip;
	//public float miVolumen;
	//public AudioMixer miAudiomixer;

	// Use this for initialization
	void Start () {
		sound = transform.parent.GetComponent<AudioSource> ();



	}
	/// <summary>
	/// funcion que reproduce cada audio y lo rutea a la salida del mixer
	/// </summary>

	public void PlaySound(){
        sound.Stop();
		AudioMixer mixer = Resources.Load("Mixers/"+miMixer) as AudioMixer;
		sound.outputAudioMixerGroup = mixer.FindMatchingGroups (outPut) [0];
		
		sound.clip = miClip;
		//sound.volume = miVolumen;

		sound.Play ();

	}


}

