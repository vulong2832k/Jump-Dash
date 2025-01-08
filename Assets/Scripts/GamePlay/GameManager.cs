using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _pauseGamePanel;

    [Header("Image")]
    [SerializeField] private GameObject _imageBestScore;
    [SerializeField] private float _rotateSpeed;

    private void Start()
    {
        Time.timeScale = 1;
        _gameOverPanel.SetActive(false);
    }
    private void Update()
    {
        OpenPauseGamePanel();
        RotateImage();
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
    private void OpenPauseGamePanel()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            _pauseGamePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void RotateImage()
    {
        _imageBestScore.transform.Rotate(0f, _rotateSpeed * Time.deltaTime, 0f);
    }
}
