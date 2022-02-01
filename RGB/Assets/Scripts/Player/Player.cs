using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{    
    public string PlayerColor { get; protected set; }

    public abstract void Special();

}
