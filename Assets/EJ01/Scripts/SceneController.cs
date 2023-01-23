using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
