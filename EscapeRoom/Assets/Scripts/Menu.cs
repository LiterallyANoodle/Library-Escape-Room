using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject gameWinMenu;
    public GameObject gameOverMenu;

    void Start()
    {
        gameWinMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public void GameWin()
    {
        gameWinMenu.SetActive(true);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void Restart()
    {
        gameWinMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }
}
