using UnityEngine;

public class OnBtn2 : MonoBehaviour
{
    private void Update()
    {
        PlayerPrefs.SetString("sfx", "on");
        PlayerPrefs.Save();
    }
}
