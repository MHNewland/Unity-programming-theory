using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSquare : Player
{
    [SerializeField]
    private bool shieldEnabled = false;
    private float shieldDuration = 1.0f;
    private float shieldUpTime = 0;
    void Start()
    {
        pColor = "GREEN";
    }
    public override void Special()
    {
        //Shield
        shieldEnabled = true;
        shieldUpTime = 0;
    }

    IEnumerator enableShield()
    {
        shieldEnabled = true;
        yield return new WaitForSeconds(shieldDuration);
    }

    void Update()
    {
        if (shieldEnabled)
        {
            shieldUpTime += Time.deltaTime;
            if(shieldUpTime >= shieldDuration)
            {
                shieldEnabled = false;
                shieldUpTime = 0;
            }
        }
    }
}
