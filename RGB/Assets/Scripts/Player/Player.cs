using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public string pColor;
    public string PlayerColor { get; protected set; }

    public abstract void Special();

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player collision");
    }

    public string getPColor()
    {
        return pColor;
    }
}
