using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScreen : MonoBehaviour
{
    GameObject mychild;
    // Use this for initialization
    void Awake()
    {
        if (transform.name == "")
        {
            mychild = transform.GetChild(0).gameObject;
            mychild.GetComponent<Button>().onClick.AddListener(() => PlayGame());

        }
        else if (transform.name == "FrutimixSplash")
        {
            StartCoroutine("SplashTime");
        }
        else if (transform.name == "PlayButton")
        {
            mychild = transform.gameObject;
            mychild.GetComponent<Button>().onClick.AddListener(() => PlayGame());
        }


    }

    public void Skip()
    {
        HudManager.instance.LoadHud(EHudScreenID.pantalla_de_juego);
    }

    public void PlayGame()
    {
        HudManager.instance.LoadHud(EHudScreenID.tuto);
    }

    IEnumerator SplashTime()
    {
        yield return new WaitForSeconds(3);
        HudManager.instance.LoadHud(EHudScreenID.MenuInicio);
    }
}
