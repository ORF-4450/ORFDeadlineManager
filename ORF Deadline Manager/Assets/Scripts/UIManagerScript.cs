using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class UIManagerScript : MonoBehaviour {

    public void LoadDeadLines()
    {
        SceneManager.LoadScene("Deadlines");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadStandings()
    {
        SceneManager.LoadScene("Standings");
    }

    public void LoadNothingToDo()
    {
        SceneManager.LoadScene("NothingToDo");
    }

    public void ToggleButtonGroup(GameObject buttonGroup)
    {
        buttonGroup.SetActive(!buttonGroup.activeSelf);
    }

    public void EnableButtonGroup(GameObject buttonGroup)
    {
        buttonGroup.SetActive(true);
        SceneManager.LoadScene("Deadlines");

    }

    public void DisableButtonGroup(GameObject buttonGroup)
    {
        buttonGroup.SetActive(false);
        Debug.Log("Disabling group: " + buttonGroup.name);
    }
    public void SortByTeam(bool sortByTeam)
    {
        PersistentObject.persitentObject.sortByTeam = sortByTeam;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
