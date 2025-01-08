using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGamePanel : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject _pauseGamePanel;

    private void Start()
    {
        Time.timeScale = 1;
        _pauseGamePanel.SetActive(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _pauseGamePanel.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;

        if (_pauseGamePanel != null)
        {
            _pauseGamePanel.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitMainMenu()
    {
        Destroy(GameObject.FindWithTag("Player"));

        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitPanel()
    {
        Time.timeScale = 1;
        _pauseGamePanel.SetActive(false);
    }
}
