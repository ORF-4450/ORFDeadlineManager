using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObject : MonoBehaviour {

    static public PersistentObject persitentObject;
    public bool sortByTeam = false;
    // Use this for initialization
    void Start()
    {
        persitentObject = (persitentObject == null) ? this : persitentObject;
    }
}
