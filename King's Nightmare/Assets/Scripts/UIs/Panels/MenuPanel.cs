using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : Panel
{
    [SerializeField] private Panel _mapSelectPanel;
    [SerializeField] private Panel _instructionPanel;
    public void StartGame()
    {
        _mapSelectPanel.gameObject.SetActive(true);
    }
    public void Setting()
    {
        PanelManager.Instance.OpenPanel(GameConfig.SETTING_PANEL);
    }
    public void Instruction()
    {
        _instructionPanel.gameObject.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}