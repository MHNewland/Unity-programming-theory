using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Obstacle
{


    void OnTriggerEnter(Collider collider)
    {

        //check to see if it's the player that was hit
        if (collider.gameObject == PlayerContainer)
        {
            Debug.Log("mine hit");
            GameManager.Instance.gameStarted = false;
        }

    }
}
