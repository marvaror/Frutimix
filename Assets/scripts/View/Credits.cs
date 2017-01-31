using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {
    public GameObject menu;
    public GameObject credi;
	// Use this for initialization
	public void Menu()
    {
        menu.SetActive(true);
        credi.SetActive(false);
    }

    public void Creditos()
    {
        menu.SetActive(false);
        credi.SetActive(true);
    }
}
