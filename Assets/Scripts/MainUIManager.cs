using UnityEngine;
using UnityEngine.EventSystems;
using static GameManager;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    void Start()
    {
        GameManager.Instance.gameOverCanvas = gameOverCanvas;
    }

    public void Restart()
    {
        GameManager.Instance.RestartGame();
    }
}
