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
            mychild.GetComponent<Button>().onClick.AddListener(() => OnClickB());

        }
        else if (transform.name == "FrutimixSplash")
        {
            StartCoroutine("SplashTime");
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickB()
    {
        HudManager.instance.LoadHud(EHudScreenID.MenuInicio);
        Debug.Log("asda");
    }

    IEnumerator SplashTime()
    {
        yield return new WaitForSeconds(3);
        HudManager.instance.LoadHud(EHudScreenID.MenuInicio);
    }
}
