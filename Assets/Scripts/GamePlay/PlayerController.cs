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

    [Header("Effect:")]
    [SerializeField] private GameObject _effectPrefab;

    [Header("Audio:")]
    [SerializeField] private AudioSource _collisionSound;

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ContactPoint2D contactPoint = collision.GetContact(0);

            Instantiate(_effectPrefab, contactPoint.point, Quaternion.identity);

            if(_collisionSound != null)
            {
                _collisionSound.Play();
            }
        }
    }
}
