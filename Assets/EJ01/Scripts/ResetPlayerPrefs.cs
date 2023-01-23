using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("sfx", "on");
        PlayerPrefs.SetString("music", "on");
        PlayerPrefs.Save();
    }

    
}
