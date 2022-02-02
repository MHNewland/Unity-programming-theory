using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCircle : Player
{
    private GameObject PlayerContainer;
    private int jumpForce = 100;

    void Start()
    {
        pColor = "BLUE";
        PlayerContainer = GameObject.FindGameObjectWithTag("PlayerContainer");
    }

    public override void Special()
    {
        //Jump
        PlayerContainer.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
