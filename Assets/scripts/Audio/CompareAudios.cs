using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CompareAudios : MonoBehaviour {

    public GameObject gano;
    public GameObject perdio;
    public GameObject final;
    public List<GameObject> audioChallenge;
    public List<string> tags;
    public List<string> tagsToEvaluate;
    public GameObject[] vidasObj;
    ReadJson myJZone;
    [SerializeField]
    private int vidas;
    AudioSource a;
    public int Misvidas
    {
        get { return vidas; }
        set { vidas = value; }
    }

    void Start() {
        a = GetComponent<AudioSource>();
        myJZone = transform.GetComponent<ReadJson>();
        tags = myJZone.TheTagsAre();
        foreach (Transform child in transform)
        {
            audioChallenge.Add(child.gameObject);

        }
    }



    public void CompareAudioClips()
    {

        GameObject muestraManager = GameObject.Find("Muestra");
        GameObject hand = GameObject.Find("hand");
        hand.GetComponent<AudioSource>().Stop();
        muestraManager.GetComponent<AudioSource>().Stop();
        bool winGame = true;
        if (tags.Count == 0)
        {
            tags = myJZone.TheTagsAre();
        }
        tagsToEvaluate.Clear();
        foreach (GameObject miNieto in audioChallenge)
        {
            if (miNieto.transform.childCount == 0)
            {
                tagsToEvaluate.Add("None");
            }
            else {
                tagsToEvaluate.Add(miNieto.transform.GetChild(0).name);
                //miNieto.transform.GetChild(0).GetComponent<slotsound>().PlaySound();
            }


        }
        for (int i = 0; i < tags.Count; i++) {
            if (tags[i].Equals(tagsToEvaluate[i])) {
                continue;
            }
            winGame = false;
        }
        AudioClip c;
        if (winGame)
        {
            c = Resources.Load("Audios/Ganar") as AudioClip;
            if (myJZone.ChangeLevel < 4)
            {
                StopSlots();
                gano.SetActive(true);
            }
            else
            {
                StopSlots();
                final.SetActive(true);
            }
        }
        else {
            c = Resources.Load("Audios/Error") as AudioClip;
            DestruirNieto();
            vidas--;
            vidasObj[vidas].GetComponent<Fade>().inTransition = true;
            if (vidas == 0)
            {
                StopSlots();
                perdio.SetActive(true);
            }

        }
        a.clip = c;
        a.Play();
    }
    void StopSlots()
    {
        foreach (GameObject miNieto in audioChallenge)
        {
            if (miNieto.transform.childCount == 0)
            {
                continue;
            }
            miNieto.transform.GetComponent<AudioSource>().Stop();
        }
    }
    public void Win() {

        StopSlots();
        tags.Clear();
        tagsToEvaluate.Clear();
        myJZone.ChangeLevel++;
        myJZone.TheTagsAre();
        DestruirNieto();
        gano.SetActive(false);
       
    }

    public void Reset()
    {
        StopSlots();
        tags.Clear();
        tagsToEvaluate.Clear();
        myJZone.ChangeLevel=5;
        DestruirNieto();
        for(int i = 0; i < vidasObj.Length; i++)
        {
            vidasObj[i].SetActive(true);
            vidasObj[i].GetComponent<Fade>().Reset();
        }
        vidas = 3;
        perdio.SetActive(false);
        gano.SetActive(false);
        perdio.SetActive(false);
        final.SetActive(false);
    }

    public void Home()
    {
        HudManager.instance.LoadHud(EHudScreenID.MenuInicio);
    }

    void DestruirNieto()
    {
        foreach (GameObject miNieto in audioChallenge)
        {
            if (miNieto.transform.childCount != 0)
            {
                Destroy(miNieto.transform.GetChild(0).gameObject);
            }

        }
    }
}

	

