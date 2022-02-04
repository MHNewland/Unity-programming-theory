using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Obstacle
{
    private Player script;

    void OnTriggerEnter(Collider collider)
    {
        //check to see if it's the player that was hit
        if (collider.gameObject == PlayerContainer)
        {
            if(PlayerContainer.TryGetComponent(out PlayerController pc))
            {
                if (pc.Player.TryGetComponent(out GreenSquare gs))
                {
                    if (gs.shieldEnabled)
                    {
                        Debug.Log("protected");
                        Destroy(gameObject);
                    }
                    else
                    {
                        Debug.Log("failed");
                        GameManager.Instance.gameStarted = false;
                    }
                }
            }
        }

    }
}
