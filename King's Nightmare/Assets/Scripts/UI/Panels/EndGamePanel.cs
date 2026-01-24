using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGamePanel : Panel
{
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private TextMeshProUGUI _lossText;
    public void Restart()
    {
        Close();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PanelManager.Instance.OpenPanel(GameConfig.GAMEPLAY_PANEL);
    }
    public void ReturnToMenu()
    {
        PanelManager.Instance.CloseAllPanel();
        SceneManager.LoadScene(GameConfig.MENU_SCENE);
        PanelManager.Instance.OpenPanel(GameConfig.MENU_PANEL);
    }
    public void OnEnable()
    {
        Time.timeScale = 0;
        UpdateResult();
        PanelManager.Instance.ClosePanel(GameConfig.GAMEPLAY_PANEL);
    }
    public void OnDisable()
    {
        _winText.gameObject.SetActive(false);
        _lossText.gameObject.SetActive(false);
    }
    public void UpdateResult()
    {
        if (PlayerPrefs.GetInt(GameConfig.SCORE) == PlayerPrefs.GetInt(GameConfig.TARGET_SCORE))
        {
            _winText.gameObject.SetActive(true);
        }
        else
        {
            _lossText.gameObject.SetActive(true);
        }
    }
}