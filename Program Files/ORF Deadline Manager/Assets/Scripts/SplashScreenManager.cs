using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SplashScreenManager : MonoBehaviour {

    public float fadeInDuration = 1f, fadeOutDuration = 1f, showDuration = 5f;

    ScrollbarAutoScroller scroller;
    ScrollbarAutoScroller.ScrollMode buffer;
    bool executing = false;
	// Use this for initialization
	void Start () {
        scroller = FindObjectOfType<ScrollbarAutoScroller>();
        if (scroller == null)
        {
            Destroy(this);
        }
        foreach (Graphic cv in GetComponentsInChildren<Graphic>())
        {
            cv.CrossFadeAlpha(0, 0, false);
        }

        Text splashText = GetComponentInChildren<Text>();
        try
        {
            using (StreamReader reader = new StreamReader(Application.dataPath + "/StreamingAssets/splashMessage.txt"))
            {
                splashText.text = reader.ReadToEnd();
            }
        }
        catch
        {
            Debug.LogWarning("Could not read from file! (does file exist?)");
            splashText.text = "Powered by demono.net®\nwhere complete chaos™ meets engineers, for maximal fun!";
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (scroller.scrollbar.value <= (1 - scroller.percentageDone) && scroller.speed > 0 && !executing)
        {
            executing = true;
            StartCoroutine(Toggle());
            
        }
    }

    IEnumerator Toggle()
    {
        Debug.Log(buffer);
        buffer = scroller.mode;
        scroller.mode = ScrollbarAutoScroller.ScrollMode.none;
        yield return new WaitForSeconds(1);
        foreach (Graphic cv in GetComponentsInChildren<Graphic>())
        {
            cv.CrossFadeAlpha(1, fadeInDuration, true);
        }

        yield return new WaitForSeconds(fadeInDuration + showDuration);

        foreach (Graphic cv in GetComponentsInChildren<Graphic>())
        {
            cv.CrossFadeAlpha(0, fadeOutDuration, true);
        }
        scroller.mode = buffer;
        scroller.ReachedEnd();
        yield return new WaitForSeconds(fadeOutDuration);
        executing = false;
        
    }
}
