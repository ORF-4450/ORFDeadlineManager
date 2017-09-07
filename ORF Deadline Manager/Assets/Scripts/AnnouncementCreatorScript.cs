using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnnouncementCreatorScript : MonoBehaviour
{
    public Text Announcement;
    public Text AnnouncementDisplay;
    
    public void DisplayAnnouncement()
    {
        AnnouncementDisplay.text = Announcement.text;
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(Application.dataPath + "/StreamingAssets/splashMessage.txt"))
        {
            try
            {
                writer.Write(Announcement.text);
            }
            catch
            {
                Debug.LogWarning("Could not write message to splashMessage.txt!");
            }
        }

    }
}
