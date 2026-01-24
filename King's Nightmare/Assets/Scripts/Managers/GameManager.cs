using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static event Action OnCanWin;
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
        King.OnPlayerDied += EndGame;
        King.OnPlayerWinGame += EndGame;
        ScoreManager.OnReachedTargetScore += OpenGate;
    }
    private void OnDisable()
    {
        King.OnPlayerDied -= EndGame;
        King.OnPlayerWinGame -= EndGame;
        ScoreManager.OnReachedTargetScore -= OpenGate;
    }
    // private void Start()
    // {
    //     PanelManager.Instance.CloseAllPanel();
    //     PanelManager.Instance.OpenPanel(GameConfig.GAMEPLAY_PANEL);
    // }
    private void EndGame()
    {
        PanelManager.Instance.OpenPanel(GameConfig.END_GAME_PANEL);
        Time.timeScale = 0;
    }
    private void OpenGate()
    {
        _gateOutAnim.SetBool(GameConfig.OPEN_GATE_BOOL, true);
        OnCanWin?.Invoke();
        Debug.Log("Opening Gate");
    }
}
