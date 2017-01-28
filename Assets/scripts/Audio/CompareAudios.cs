using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareAudios : MonoBehaviour {

    public GameObject[] audioChallenge; 
    public GameObject[] audioUser;


    void Start (){
        
    }

    void Update() {

        string nameAudioChallenge = "";
        string nameAudioUser = "";

        audioChallenge = GameObject.FindGameObjectsWithTag("Audio_Challenge");

        for (int i = 0; i < audioChallenge.Length; i++)
        {
            nameAudioChallenge = nameAudioChallenge + audioChallenge[i].name;
        }

        audioUser = GameObject.FindGameObjectsWithTag("Audio_Usuario");
        
        for (int i = 0; i < audioUser.Length; i++)
        {
            nameAudioUser = nameAudioUser + audioUser[i].name;
        }

        CompareAudioClips(nameAudioChallenge,nameAudioUser);
    }

    public void CompareAudioClips(string nombreAudioReto, string nombreAudioUsuario)
    {

        bool winGame = true;
        if (nombreAudioReto == nombreAudioUsuario)
        {
            winGame = true;
            Win(winGame);
            Debug.Log("GANASTE!!!");
        }
        else {
            winGame = false;
            Win(winGame);
            Debug.Log("PERDISTE, DEBES PRACTICAR MAS!!!");
        }

    }

    public void Win(bool ganador){

    
    }
}

	

