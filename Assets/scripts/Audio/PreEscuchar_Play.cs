using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PreEscuchar_Play : MonoBehaviour {

	AudioSource sound;
	public string miMixer;
    public string outPut;
    public AudioClip miClip;
	GameObject muestra;
    GameObject zonaColocacion;
    int numChildren;
    //public float miVolumen;
    //public AudioMixer miAudiomixer;

    // Use this for initialization
    void Start () {
		sound = transform.parent.GetComponent<AudioSource> ();
		muestra = GameObject.Find("Muestra");
        zonaColocacion = GameObject.Find("zonacolocacion");
        numChildren = zonaColocacion.transform.childCount;

    }
	/// <summary>
	/// funcion que reproduce cada audio y lo rutea a la salida del mixer
	/// </summary>

	public void PlaySound(){

		muestra.GetComponent<AudioSource>().Stop();
        for (int i = 0; i < numChildren; ++i)
        {
            zonaColocacion.transform.GetChild(i).GetComponent<AudioSource>().Stop();
        }
        sound.Stop();
		AudioMixer mixer = Resources.Load("Mixers/"+miMixer) as AudioMixer;
		sound.outputAudioMixerGroup = mixer.FindMatchingGroups (outPut) [0];
		
		sound.clip = miClip;
		//sound.volume = miVolumen;

		sound.Play ();

	}


}

