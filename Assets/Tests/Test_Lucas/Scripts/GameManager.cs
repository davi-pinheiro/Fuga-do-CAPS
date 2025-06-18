using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;

    void Start()
    {
        // Pausar o tempo do jogo ao iniciar
        Time.timeScale = 0f;
        startPanel.SetActive(true);
    }

    public void StartGame()
    {
        // Retomar o tempo do jogo
        Time.timeScale = 1f;
        startPanel.SetActive(false);
    }
}
