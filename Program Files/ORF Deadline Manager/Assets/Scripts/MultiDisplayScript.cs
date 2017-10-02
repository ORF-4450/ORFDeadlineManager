using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiDisplayScript : MonoBehaviour {

    Camera[] myCams = new Camera[2];
    static MultiDisplayScript multiDisp;
	// Use this for initialization
	void Start () {
        if (multiDisp == null)
        {
            DontDestroyOnLoad(gameObject);
            multiDisp = this;
            myCams[0] = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            myCams[1] = GameObject.Find("Camera2").GetComponent<Camera>();
            Display.onDisplaysUpdated += OnDisplaysUpdated;
            CameraToDisplay();
        }
        else
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void CameraToDisplay () {
        for (int i = 0; i < Display.displays.Length; i++)
        {
            myCams[i].targetDisplay = i; //Set the Display in which to render the camera to
            Display.displays[i].Activate(); //Enable the display
        }

       
    }
    void OnDisplaysUpdated()
    {
        Debug.Log("New Display Connected. Show Display Option Menu....");
    }
}
