using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Fade : MonoBehaviour {
    public bool fadeOut = true;
    public bool mid = false;
    public bool allCanvasGroup = false;
    public float speed = 1.0f;
    Image im;
    CanvasGroup g;
    Color currentColor;
    public bool inTransition = false;
    bool change = false;
    // Use this for initialization
    void Start() {
        im = GetComponent<Image>();
        if (allCanvasGroup)
        {
            g = GetComponent<CanvasGroup>();
        }
        currentColor = im.color;
        if (fadeOut)
        {
            currentColor.a = 1;
            if (allCanvasGroup)
            {
                g.alpha = 1;
            }
           
        }
        else
        {
            currentColor.a = 0;
            if (allCanvasGroup)
            {
                g.alpha = 0;
            }
           
        }
    }

    public bool Transition { get { return inTransition; } set { inTransition = value; } }
    
	// Update is called once per frame
	void Update () {
        if (inTransition) {
            float a = Time.deltaTime / speed;
            if (mid)
            {
                if (fadeOut)
                {

                    if ( !change)
                    {
                        currentColor.a -= a;
                        if (currentColor.a <= 0.1)
                        {
                            change = true;
                        }
                    }
                    else
                    {
                       
                        currentColor.a += a;
                        if (currentColor.a >= 1)
                        {
                            Reset();
                        }
                    }
                }
               
            }
            else {
                if (fadeOut)
                {
                    currentColor.a -= a;
                }
                else
                {
                    currentColor.a += a;
                }
            }
            if (allCanvasGroup)
            {
                g.alpha = currentColor.a;
            }
            
            im.color = new Color(im.color.r, im.color.g, im.color.b, currentColor.a);
            if (currentColor.a <= 0 && fadeOut)
            {

                gameObject.SetActive(false);
                Reset();
            }
            
        }
       
	}

    public void Reset()
    {
        inTransition = false;
        change = false;
        im = GetComponent<Image>();
        if (fadeOut)
        {
            currentColor.a = 1;
            if (allCanvasGroup)
            {
                g.alpha = 1;
            }
           
        }
        else
        {
            currentColor.a = 0.1f;
            if (allCanvasGroup)
            {
                g.alpha = 0.1f;
            }
            
        }
        if(im.GetComponent<Image>() != null)
        im.color = new Color(im.color.r, im.color.g, im.color.b, currentColor.a);
    }


}
