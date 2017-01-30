using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class slotsound : MonoBehaviour
{



    AudioSource sound;
    public string miMixer;
    public string outPut;
    public AudioClip miClip;
    GameObject muestra;
    //public float miVolumen;
    //public AudioMixer miAudiomixer;

    // Use this for initialization
    void Start()
    {
        
        muestra = GameObject.Find("Muestra");



    }
    /// <summary>
    /// funcion que reproduce cada audio y lo rutea a la salida del mixer
    /// </summary>

    public void PlaySound()
    {
        sound = transform.parent.GetComponent<AudioSource>();
        muestra.GetComponent<AudioSource>().Stop();
        sound.Stop();
        AudioMixer mixer = Resources.Load("Mixers/" + miMixer) as AudioMixer;
        sound.outputAudioMixerGroup = mixer.FindMatchingGroups(outPut)[0];

        sound.clip = miClip;
       

        sound.Play();

    }
}