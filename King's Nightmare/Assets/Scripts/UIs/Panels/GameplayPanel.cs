using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayPanel : Panel
{
    public static event Action OnNewGame;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _targetScoreText;
    private void OnEnable()
    {
        ScoreManager.OnUpdateScore += UpdateScoreText;
    }
    private void OnDisable()
    {
        ScoreManager.OnUpdateScore -= UpdateScoreText;
    }
    private void Start()
    {
        OnNewGame?.Invoke();
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        Debug.Log("Update Score Text");
        _scoreText.text = PlayerPrefs.GetInt(GameConfig.SCORE, 0).ToString();
        _targetScoreText.text = PlayerPrefs.GetInt(GameConfig.TARGET_SCORE, 0).ToString();
    }
    public void Pause()
    {
        PanelManager.Instance.OpenPanel(GameConfig.PAUSE_PANEL);
    }
}