using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    [SerializeField] protected GameObject parent;
    private void Start()
    {
        Destroy(parent, 2f);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(GameTag.Player.ToString()))
        {
            Destroy(col.gameObject);
            if (GameManager.Ins)
            {
                GameManager.Ins.state = GameState.Gameover;
            }

            if (GUIManager.Ins || GUIManager.Ins.gameoverDialog)
            {
                GUIManager.Ins.gameoverDialog.Show(true);
            }

            if (AudioController.Ins)
            {
                AudioController.Ins.PlaySound(AudioController.Ins.gameover);
            }
            Debug.Log("GameOver!");

        }
    }
}
