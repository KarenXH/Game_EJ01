using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnBtn1 : MonoBehaviour
{
    private void LateUpdate()
    {
        PlayerPrefs.SetString("music", "on");
        PlayerPrefs.Save();
    }
}
