using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    [SerializeField] protected GameObject parent;
    private void Start()
    {
        Destroy(parent, 2f);
    }

}
