using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : PuzzleObject {

    public int number;
    private int counter;
    private float timeOn = 0.7f;
    private float timeOff = 0.3f;
    private Light light;
    private float changeTime = 0f;
    private bool go;

    // Use this for initialization
    void Start()
    {
        go = false;
        light = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > changeTime)
        {
            light.enabled = !light.enabled;
            if (light.enabled)
            {
                changeTime = Time.time + timeOn;
            }
            else
            {
                changeTime = Time.time + timeOff;
                counter++;
            }
        }

        if(counter == number)
        {
            counter = 0;
            changeTime += 2.0f;
        }
    }
}