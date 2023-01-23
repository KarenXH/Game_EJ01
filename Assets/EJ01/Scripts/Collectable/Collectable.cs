using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreBonus;
    public GameObject explosionEffectPre;

    public void Trigger()
    {
        if (explosionEffectPre)
        {
            Instantiate(explosionEffectPre, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);

        if (GameManager.Ins)
        {
            GameManager.Ins.AddScore(scoreBonus);
        }

        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.gotCollectable);
        }
    }
}
