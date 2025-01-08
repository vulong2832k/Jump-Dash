using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _distanceY;

    void Update()
    {
        MovingObstacle();
    }
    private void MovingObstacle()
    {
        //Moving
        transform.position += Vector3.down * _moveSpeed * Time.deltaTime;

        //Condition
        if (transform.position.y <= _distanceY)
        {
            ScoreManager.Instance.AddScore(1);
            gameObject.SetActive(false);
        } 
    }
}
