using UnityEngine;

public class GetDataVolume : MonoBehaviour
{
    [SerializeField] protected GameObject OnBtn1;
    [SerializeField] protected GameObject OffBtn1;
    [SerializeField] protected GameObject OnBtn2;
    [SerializeField] protected GameObject OffBtn2;
    void Awake()
    {
        if (PlayerPrefs.GetString("music") == "on")
        {
            OnBtn1.SetActive(true);
            OffBtn1.SetActive(false);
        }
        else if (PlayerPrefs.GetString("music") == "off")
        {
            OnBtn1.SetActive(false);
            OffBtn1.SetActive(true);
        }

        if (PlayerPrefs.GetString("sfx") == "on")
        {
            OnBtn2.SetActive(true);
            OffBtn2.SetActive(false);
        }
        else if (PlayerPrefs.GetString("sfx") == "off")
        {
            OnBtn2.SetActive(false);
            OffBtn2.SetActive(true);
        }
    }
}
