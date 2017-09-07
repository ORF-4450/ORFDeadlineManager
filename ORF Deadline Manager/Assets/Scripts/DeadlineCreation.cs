using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadlineCreation : MonoBehaviour
{

    public GameObject Panel;
    public GameObject Panel2;
    public GameObject Panel3;

    public void showhidePanel()
    {
            //Toggle the state of the panel gameobject
            Panel.gameObject.SetActive(!Panel.gameObject.activeSelf);
    }

    public void showhideDeadlines()
    {
        //Toggle the state of the panel gameobject
        Panel2.gameObject.SetActive(!Panel2.gameObject.activeSelf);
    }

    public void showhideAnnouncements()
    {
        //Toggle the state of the panel gameobject
        Panel3.gameObject.SetActive(!Panel2.gameObject.activeSelf);
    }
}
