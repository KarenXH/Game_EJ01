using UnityEngine;

public class PauseDialog : Dialog
{
    public override void Show(bool isShow)
    {
        base.Show(isShow);
        Time.timeScale = 0f;
    }

    public void Remuse()
    {
        Time.timeScale = 1f;
        Close();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        if (SceneController.Ins)
        {
            SceneController.Ins.LoadCurrentScene();
        }
    }
}
