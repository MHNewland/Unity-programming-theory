using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int speed = 10;
    private int leftBounds = -10;

    [SerializeField]
    protected GameObject PlayerContainer;

    private void Awake()
    {
        PlayerContainer = GameObject.FindGameObjectWithTag("PlayerContainer");
    }

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
