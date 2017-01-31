using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudTutorial : MonoBehaviour {

    private Image animation;
    //private Sprite currentImage;

    private int imageIndex = 0;

	// Use this for initialization
	void Start () {

        // Referenciamos el contenedor de las imagenes
        animation = GameObject.Find("Animation").gameObject.GetComponent<Image>();

        // Define the first image index
        imageIndex = 0;

        // Changes the image displayed
        InvokeRepeating("changeImage", 0f, 0.05f);
    }

    void changeImage() {
        Debug.Log("changeImage index:" + imageIndex);

        // Define the size of the rect transform
        animation.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);

        Texture2D newImage = Resources.Load<Texture2D>("Sprites/Tutorial/Escena_Juego-02_000" + getFormattedNumber(imageIndex));
        Debug.Log(newImage.name);

        // Cargo un sprite asset
        Sprite currentImage = Sprite.Create(newImage, new Rect(0, 0, 1024, 576), Vector2.one * 0.5f);
        Debug.Log(currentImage.bounds);

        // Load the sprite in the container
        animation.sprite = currentImage;

        // Change the index
        imageIndex += 1;

        // if index overflows the sprite array size
        if (imageIndex > 55) {
            imageIndex = 0;
        }
    }

    private string getFormattedNumber(int number)
    {
        if (number < 10) {
            return "0" + number.ToString();
        } else {
            return number.ToString();
        }
    }

}
