using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTriangle : Player
{
    public GameObject laser;

    void Start()
    {
        pColor = "RED";
    }

    public override void Special()
    {
        //laser
        Instantiate(laser, transform.position, laser.transform.rotation);
    }

}
