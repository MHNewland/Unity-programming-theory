using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int speed = 10;
    private int leftBounds = -10;

    void Update()
    {
        if (GameManager.Instance.gameStarted)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (transform.position.x < leftBounds)
        {
            Destroy(gameObject);
        }
    }
}
