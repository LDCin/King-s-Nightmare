using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    private void OnEnable()
    {
        King.OnPlayerDied += GameOver;
    }
    private void OnDisable()
    {
        King.OnPlayerDied -= GameOver;
    }
    private void GameOver()
    {
        GameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
