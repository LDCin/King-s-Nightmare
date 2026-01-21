using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGamePanel : Panel
{
    [ContextMenu("Test Restart")]
    public void Restart()
    {
        Close();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    [ContextMenu("Test Menu")]
    public void ReturnToMenu()
    {
        Close();
        SceneManager.LoadScene(GameConfig.MENU_SCENE);
        
    }
}