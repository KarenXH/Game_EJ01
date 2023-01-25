using UnityEngine;

public class Dust : MonoBehaviour
{
    public void StopDust()
    {
        Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
    }
}
