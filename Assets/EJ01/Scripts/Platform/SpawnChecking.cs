using UnityEngine;

public class SpawnChecking : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GameTag.Platform.ToString()))
        {
            var playformCol = col.GetComponent<Platform>();

            if (!playformCol || !GameManager.Ins || !GameManager.Ins.LastPlatformSpawned) return;

            if(playformCol.IdPlatform == GameManager.Ins.LastPlatformSpawned.IdPlatform)
            {
                GameManager.Ins.SpawnPlatform();
            }

        }
    }
}
