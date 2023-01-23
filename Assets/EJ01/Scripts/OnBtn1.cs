using UnityEngine;

public class OnBtn1 : MonoBehaviour
{
    private void LateUpdate()
    {
        PlayerPrefs.SetString("music", "on");
        PlayerPrefs.Save();
    }
}
