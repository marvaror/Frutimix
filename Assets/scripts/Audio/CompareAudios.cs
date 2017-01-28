using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareAudios : MonoBehaviour {

    public GameObject gano;
    public GameObject perdio;
    public List<GameObject> audioChallenge; 
    public List<string> tags;
    public List<string> tagsToEvaluate;
    ReadJson myJZone;

    void Start (){
        myJZone = transform.GetComponent<ReadJson>();
        tags = myJZone.TheTagsAre();
        foreach (Transform child in transform)
        {
            audioChallenge.Add(child.gameObject);
          
        }
    }

    void Update() {

  
    }

    public void CompareAudioClips()
    {
        tags = myJZone.TheTagsAre();
        bool winGame=true;
        foreach(GameObject miNieto in audioChallenge){
            if (miNieto.transform.childCount == 0)
            {
                tagsToEvaluate.Add("None");
            }
            else {
                tagsToEvaluate.Add(miNieto.transform.GetChild(0).name);
            }

           
        }
        
        for(int i=0; i<tags.Count; i++){
            if(tags[i].Equals(tagsToEvaluate[i])){
                continue;
            }
            winGame = false;
        }

        if (winGame)
        {
            gano.SetActive(true);
        }
        else {
            perdio.SetActive(true);
        }

        


    }

    public void Win(){
        myJZone.level++;
        tags.Clear();
        tagsToEvaluate.Clear();
        foreach (GameObject miNieto in audioChallenge)
        {
            if (miNieto.transform.childCount != 0)
            {
                Destroy(miNieto.transform.GetChild(0));
            }
     
        }
    }
}

	

