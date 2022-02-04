using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCircle : Player
{
    private GameObject PlayerContainer;
    private int jumpForce = 200;
    private bool onGround = true;

    void Start()
    {
        pColor = "BLUE";
        PlayerContainer = GameObject.FindGameObjectWithTag("PlayerContainer");
    }

    public override void Special()
    {
        //Jump
        if (onGround)
        {
            PlayerContainer.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Base")
        {
            Debug.Log("landed");
            onGround = true;
        }
    }

}
