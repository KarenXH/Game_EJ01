using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] protected GameObject _enemy;
    void TurnOnEnemy()
    {
        _enemy.SetActive(true);
    }
}
