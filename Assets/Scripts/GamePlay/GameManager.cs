using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        Time.timeScale = 1;
        _gameOverPanel.SetActive(false);
    }
    private void Update()
    {
        OpenGameOverPanel();
    }
    public void GameOver()
    {
        Time.timeScale = 0;

        ScoreManager.Instance.SaveScore();

        if (_gameOverPanel != null)
        {
            _gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        if (_gameOverPanel != null)
        {
            _gameOverPanel.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitToMainMenu()
    {
        Destroy(GameObject.FindWithTag("Player"));

        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    private void OpenGameOverPanel()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
