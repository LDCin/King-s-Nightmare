using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static event Action OnCanWin;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _winGamePanel;
    [SerializeField] GameObject _gateIn;
    [SerializeField] GameObject _gateOut;
    [SerializeField] private Animator _gateOutAnim;
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        King.OnPlayerDied += GameOver;
        King.OnPlayerWinGame += Win;
        ScoreManager.OnReachedTargetScore += OpenGate;
    }
    private void OnDisable()
    {
        King.OnPlayerDied -= GameOver;
        King.OnPlayerWinGame -= Win;
        ScoreManager.OnReachedTargetScore -= OpenGate;

    }
    private void GameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    [ContextMenu("Test Open Gate")]
    private void OpenGate()
    {
        _gateOutAnim.SetBool(GameConfig.OPEN_GATE_BOOL, true);
        OnCanWin?.Invoke();
        Debug.Log("Opening Gate");
    }
    [ContextMenu("Test Win")]
    private void Win()
    {
        _winGamePanel.gameObject.SetActive(true);
    }

}
