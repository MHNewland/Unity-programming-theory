using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : Obstacle
{
    public string gateColor;
    private string playerColor;
    private GameObject[] Gates;


    void OnTriggerEnter(Collider collider)
    {
        //check to see if it's the player that was hit
        if (collider.gameObject == PlayerContainer)
        {
            //get the color of the player and store it
            playerColor = PlayerContainer.GetComponent<PlayerController>().Player.GetComponent<Player>().getPColor();

            //If the color of the player and the gate don't match when the gate is hit, game over.
            if (playerColor != gateColor)
            {
                Debug.Log("Game Over");
                GameManager.Instance.gameStarted = false;
            }
            else
            {
                Debug.Log("passed");
            }
        }

    }
}
