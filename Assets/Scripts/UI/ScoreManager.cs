using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private int _curScore = 0;
    private const string _highScoreKey = "best:";

    public System.Action<int> OnScoreChangeColorGround;
    private int _nextThreshold = 5;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void AddScore(int amount)
    {
        _curScore += amount;

        if (_curScore >= _nextThreshold)
        {
            if (OnScoreChangeColorGround != null)
            {
                OnScoreChangeColorGround.Invoke(_curScore);
            }
            _nextThreshold += 5;
        }
    }

    public int GetCurScore()
    {
        return _curScore;
    }
    public void SaveScore()
    {
        int highScore = PlayerPrefs.GetInt(_highScoreKey, 0);

        if (_curScore > highScore)
        {
            PlayerPrefs.SetInt(_highScoreKey, _curScore);
            PlayerPrefs.Save();
        }
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(_highScoreKey, 0);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(_highScoreKey, 0);
        PlayerPrefs.Save();
    }
}
