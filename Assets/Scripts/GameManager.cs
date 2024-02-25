using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject gameOverCanvas;
    public bool IsGameOver
    {
        get => isGameOver;
        set
        {
            Debug.Log("Game Over set to: "+value);
            if (gameOverCanvas != null) { gameOverCanvas.SetActive(value); }
            isGameOver = value;
        }
    }
    private bool isGameOver = true;

    public enum DifficultyType
    {
        Easy,
        Medium,
        Hard
    }

    private DifficultyType m_difficulty;
    public DifficultyType Difficulty { get => m_difficulty; set => m_difficulty = value; }

    public void StartGame(string DifficultyStr)
    {
        Difficulty = (DifficultyType)System.Enum.Parse(typeof(DifficultyType), DifficultyStr);
        isGameOver = false;
        SceneManager.LoadScene(1);
    }
    public void RestartGame()
    {
        IsGameOver = false;
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
