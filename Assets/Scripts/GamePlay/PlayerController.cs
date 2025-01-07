using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Game Object:")]
    private Rigidbody2D _playerRb;

    [Header("Attribute:")]
    [SerializeField] private float _jumpForce;

    [Header("Bool:")]
    private bool _movingRight = true;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_movingRight)
            {
                _playerRb.velocity = new Vector2(_jumpForce, 0);
            }
            if (!_movingRight)
            {
                _playerRb.velocity = new Vector2(-_jumpForce, 0);
            }
            _movingRight = !_movingRight;
        }
    }
}
