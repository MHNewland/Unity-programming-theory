using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed = 10;
    private float rightBounds = 9;

    private void Update()
    {
        if (GameManager.Instance.gameStarted)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x > rightBounds)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("shot " + collider.gameObject.name);
        if(collider.gameObject.CompareTag("TNT"))
        {
            Debug.Log("TNT");
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
