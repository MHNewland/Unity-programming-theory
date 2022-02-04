using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : Obstacle
{
    void OnTriggerEnter(Collider collider)
    {
        //check to see if it's the player that was hit
        if (collider.gameObject == PlayerContainer)
        {
            Debug.Log("TNT hit");
            GameManager.Instance.gameStarted = false;
        }
    }
}
