using UnityEngine;

public class OffBtn2 : MonoBehaviour
{
    private void Update()
    {
        PlayerPrefs.SetString("sfx", "off");
        PlayerPrefs.Save();
    }
}
