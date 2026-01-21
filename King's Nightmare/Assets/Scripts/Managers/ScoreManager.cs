using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : Singleton<ScoreManager>
{
    public static event Action OnUpdateScore;
    public static event Action OnReachedTargetScore;

    [SerializeField] private int _score = 0;
    [SerializeField] private int _targetScore = 0;

    private void OnEnable()
    {
        Pig.OnPigDied += HandlePigDied;
        GameplayPanel.OnNewGame += HandleNewGame;
    }

    private void OnDisable()
    {
        Pig.OnPigDied -= HandlePigDied;
        GameplayPanel.OnNewGame -= HandleNewGame;
    }
    public override void Awake()
    {
        UpdateTargetScore();
        UpdateScore(0);
    }

    // private void Start()
    // {
    //     UpdateTargetScore();
    //     UpdateScore(0);
    // }

    private void HandlePigDied()
    {
        UpdateScore(_score + 1);
    }

    private void HandleNewGame()
    {
        UpdateTargetScore();
        UpdateScore(0);
    }

    private void UpdateScore(int newScore)
    {
        _score = newScore;
        PlayerPrefs.SetInt(GameConfig.SCORE, _score);
        OnUpdateScore?.Invoke();

        if (_score >= _targetScore)
            OnReachedTargetScore?.Invoke();
    }

    private void UpdateTargetScore()
    {
        _targetScore = Resources.Load<MapData>("SOs/MapData/" + SceneManager.GetActiveScene().name).pigQuantity;
        PlayerPrefs.SetInt(GameConfig.TARGET_SCORE, _targetScore);
    }
}
