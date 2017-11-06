using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class XMLDeadline : MonoBehaviour {

   public static XMLDeadline XML;

   public InputField Title;
   public InputField Description;
   public InputField DueDate;
   public InputField Author;
   public Dropdown Team;

   public Button SubmitButton;
   public Button CompletedButton;
   
   public DeadlineDB deadlineDB;

   public GameObject ErrorObject;

    // Use this for initialization
    public void Start()
    {
        XML = this;
        LoadDeadline();
    }


    public void SaveDeadline()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(DeadlineDB));
        //FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/DeadlineDB.xml", FileMode.Create);
        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/StreamingAssets/XML/DeadlineDB.xml", false, Encoding.UTF8))
        {
            serializer.Serialize(sw, deadlineDB);
        }
        //serializer.Serialize(stream, deadlineDB);
        //stream.Close();
        Title.text = "";
        Description.text = "";
        DueDate.text = "";
        Author.text = "";
        //Team.text = "";

    }

    public void LoadDeadline() {
        XmlSerializer serializer = new XmlSerializer(typeof(DeadlineDB));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/DeadlineDB.xml", FileMode.Open);
        deadlineDB = serializer.Deserialize(stream) as DeadlineDB;
        stream.Close();
    }

    public void DeleteDeadline(GameObject entry) 
    {
        string title = "";
        foreach (Text t in entry.GetComponentsInChildren<Text>())
            if (t.name.ToLower() == "project")
            {
                title = t.text;
                break;
            }

        foreach (DeadLineEntry ded in deadlineDB.DeadLineList) 
        {
            
            if (title.ToLower() == ded.Title.ToLower()) 
            {
                deadlineDB.DeadLineList.Remove(ded);
                SaveDeadline();
                SceneManager.LoadScene("Deadlines");
                break;
            }
        }

        
    }

    public void ValidateInput()
    {
        bool gotError = false;
        string errorMessage = "";
        foreach (DeadLineEntry entry in deadlineDB.DeadLineList)
        {
            if (entry.Title.ToLower() == Title.text.ToLower())
            {
                gotError = true;
                errorMessage += "A deadline with this title does already exist!\n";
            }
        }
        DateTime date;
        Debug.Log(DueDate.text.Trim());
        if (!DateTime.TryParseExact(DueDate.text.Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            gotError = true;
            errorMessage += "Due date has to be in the format of: \"MM/dd/yyyy\"!";
        }

        if (gotError)
        {
            StartCoroutine(showWarning(errorMessage));
        }
        else
        {
            DeadLineEntry entry = new DeadLineEntry(Title.text, Description.text, DueDate.text, Author.text, Team.captionText.text);
            deadlineDB.DeadLineList.Add(entry);
            SaveDeadline();
            SceneManager.LoadScene("Deadlines");
        }
    }

    IEnumerator showWarning(string errorMessage)
    {
        ErrorObject.GetComponentInChildren<Text>().text = errorMessage;
        ErrorObject.SetActive(true);
        yield return new WaitForSeconds(5);
        ErrorObject.SetActive(false);
    }


    [System.Serializable]
    public class DeadLineEntry
    {
        public DeadLineEntry()
        {
            Title = "";
            Description = "";
            DueDate = "";
            Author = "";
            Team = "";
        }

        public DeadLineEntry(string title, string desc, string due, string author, string team)
        {
            Title = title;
            Description = desc;
            DueDate = due;
            Author = author;
            Team = team;
        }

        public string
        Author,
        Title,
        DueDate,
        Description,
        Team;
    }

    [System.Serializable]
    public class DeadlineDB  {
        public List<DeadLineEntry> DeadLineList = new List<DeadLineEntry>();
     
    }



}
