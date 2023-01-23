using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager>
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject gamePlay;
    [SerializeField] public Text scoreText;
    [SerializeField] public PauseDialog pauseDialog;
    [SerializeField] public GameOverDialog gameoverDialog;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowGameplay(bool isShow)
    {
        if (gamePlay)
        {
            gamePlay.SetActive(isShow);
        }

        if (mainMenu)
        {
            mainMenu.SetActive(!isShow);
        }
    }

    public void UpdateScore(int score)
    {
        if (scoreText)
        {
            scoreText.text = " Score: "+score.ToString();
        }
    }
}
