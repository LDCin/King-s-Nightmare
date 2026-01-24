using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinGamePanel : Panel
{
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private TextMeshProUGUI _lossText;
    public void Restart()
    {
        Close();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnToMenu()
    {
        PanelManager.Instance.CloseAllPanel();
        SceneManager.LoadScene(GameConfig.MENU_SCENE);
    }
    public void OnEnable()
    {
        UpdateResult();
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