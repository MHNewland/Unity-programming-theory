using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSquare : Player
{
    
    public bool shieldEnabled { get; set; }
    private float shieldDuration = 1.0f;
    private float shieldFadeTime = 0.75f;
    private float shieldUpTime = 0;
    private GameObject shield;

    private float baseAlpha;
    [SerializeField]
    private float currentAlpha;

    void Start()
    {
        shield = GameObject.Find("Shield");
        baseAlpha = shield.GetComponent<Renderer>().material.color.a;
        pColor = "GREEN";
        shieldEnabled = false;
    }
    public override void Special()
    {
        //Shield
        shieldEnabled = true;
        currentAlpha = baseAlpha;
        shieldUpTime = 0;
    }

    void Update()
    {
        shield.SetActive(shieldEnabled);

        if (shieldEnabled)
        {
            Color shieldColor = shield.GetComponent<Renderer>().material.color;
            shieldUpTime += Time.deltaTime;
            if (shieldUpTime >= shieldDuration)
            {
                shieldEnabled = false;
                shieldUpTime = 0;
            }
            if (shieldUpTime > shieldFadeTime)
            {
                //subtract (% time left * % of baseAlpha) to get what the current alpha should be
                currentAlpha = shieldColor.a - Time.deltaTime*((shieldUpTime/shieldDuration) * currentAlpha/baseAlpha);
                if (currentAlpha < 0) currentAlpha = 0;
            }
            shield.GetComponent<Renderer>().material.color = new Color(shieldColor.r, shieldColor.g, shieldColor.b, currentAlpha);
        }
    }


}
