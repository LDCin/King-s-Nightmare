using System;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayPanel : Panel
{
    public static event Action OnNewGame;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _targetScoreText;
    [SerializeField] private List<Image> _hPUI = new List<Image>();
    private void OnEnable()
    {
        ScoreManager.OnUpdateScore += UpdateScoreText;
        King.OnPlayerTakeDamage += UpdateHP;
        UpdateHP(3);
    }
    private void OnDisable()
    {
        ScoreManager.OnUpdateScore -= UpdateScoreText;
        King.OnPlayerTakeDamage -= UpdateHP;
    }
    private void Start()
    {
        OnNewGame?.Invoke();
        UpdateScoreText();
        // UpdateHP(3);
    }
    private void UpdateScoreText()
    {
        Debug.Log("Update Score Text");
        _scoreText.text = PlayerPrefs.GetInt(GameConfig.SCORE, 0).ToString();
        _targetScoreText.text = PlayerPrefs.GetInt(GameConfig.TARGET_SCORE, 0).ToString();
    }
    private void UpdateHP(int hp)
    {
        for (int i = 0; i < _hPUI.Count; i++)
        {
            if (i < hp)
            {
                ColorUtility.TryParseHtmlString("#FF8383", out Color c);
                _hPUI[i].color = c;
            }
            else
            {
                ColorUtility.TryParseHtmlString("#FFFFFF", out Color c);
                _hPUI[i].color = c;
            }
        }
    }
    public void Pause()
    {
        Debug.Log("Open Pause Panel");
        Close();
        PanelManager.Instance.OpenPanel(GameConfig.PAUSE_PANEL);
    }
}