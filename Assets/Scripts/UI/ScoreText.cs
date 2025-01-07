using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private void Update()
    {
        // Cập nhật Text hiển thị
        _scoreText.text = " " + ScoreManager.Instance.GetCurScore();
        _highScoreText.text = "best: " + ScoreManager.Instance.GetHighScore().ToString("D4");
    }
}
