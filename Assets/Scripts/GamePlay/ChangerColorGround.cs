using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerColorGround : MonoBehaviour
{
    private Renderer _renderColor;

    private void Start()
    {
        _renderColor = GetComponent<Renderer>();

        ScoreManager.Instance.OnScoreChangeColorGround += ChangeColorGround;
    }

    private void OnDestroy()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChangeColorGround -= ChangeColorGround;
        }
    }

    private void ChangeColorGround(int score)
    {
        Color randomColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );

        if (_renderColor != null)
            _renderColor.material.color = randomColor;
    }
}
