using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PausePanel : Panel
{
    public void OnEnable()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        // PanelManager.Instance.OpenPanel(GameConfig.GAMEPLAY_PANEL);
        Close();
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        Close();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PanelManager.Instance.OpenPanel(GameConfig.GAMEPLAY_PANEL);
    }
    public void ReturnToMenu()
    {
        PanelManager.Instance.CloseAllPanel();
        SceneManager.LoadScene(GameConfig.MENU_SCENE);
        PanelManager.Instance.OpenPanel(GameConfig.MENU_PANEL);
    }
    public void Setting()
    {
        PanelManager.Instance.OpenPanel(GameConfig.SETTING_PANEL);
    }
}