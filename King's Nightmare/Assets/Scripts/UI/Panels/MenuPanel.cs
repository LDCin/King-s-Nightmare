using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : Panel
{
    // [SerializeField] private Panel _mapSelectPanel;
    [SerializeField] private Panel _instructionPanel;
    public void StartGame()
    {
        // _mapSelectPanel.gameObject.SetActive(true);
        // PanelManager.Instance.CloseAllPanel();
        Time.timeScale = 1;
        SceneManager.LoadScene(GameConfig.MAP_1_SCENE);
        PanelManager.Instance.CloseAllPanel();
        PanelManager.Instance.OpenPanel(GameConfig.GAMEPLAY_PANEL);
    }
    public void Setting()
    {
        PanelManager.Instance.OpenPanel(GameConfig.SETTING_PANEL);
    }
    public void Tutorial()
    {
        _instructionPanel.gameObject.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}