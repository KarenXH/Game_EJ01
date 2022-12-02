using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffBtn1 : MonoBehaviour
{
    private void Update()
    {
        PlayerPrefs.SetString("music", "off");
        PlayerPrefs.Save();
    }
}
