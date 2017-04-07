using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : PuzzleObject
{
    public GameObject playerpub;
    private Vector3 playerpos;
    bool unlocked = false;
    public float openThreshhold;
    private bool lessthan = false;
    public bool clockwise = true;

    public override void activate()
    {
        unlocked = true;
    }
    void Start ()
    {
        if(gameObject.transform.eulerAngles.y < openThreshhold)
        {
            lessthan = true;
        }
    }
    void Update ()
    {
        
        if(lessthan && unlocked)
        {
            if (!clockwise)
            {
                    if (gameObject.transform.eulerAngles.y < openThreshhold)
                    {
                        gameObject.transform.Rotate(0, 50 * Time.deltaTime, 0);
                    }
                    else
                    {
                        gameObject.transform.eulerAngles = new Vector3(0f, openThreshhold, 0f);
                        unlocked = false;
                    }
                

            }
            else
            {
                    if (gameObject.transform.eulerAngles.y < openThreshhold)
                    {
                        gameObject.transform.Rotate(0, -50 * Time.deltaTime, 0);
                    }
                    else
                    {
                        gameObject.transform.eulerAngles = new Vector3(0f, openThreshhold, 0f);
                        unlocked = false;
                    }
                
            }
        }
        else
        {
            if (!clockwise)
            {
                if (unlocked)
                {
                    if (gameObject.transform.eulerAngles.y > openThreshhold)
                    {
                        gameObject.transform.Rotate(0, 50 * Time.deltaTime, 0);
                    }
                    else
                    {
                        gameObject.transform.eulerAngles = new Vector3(0f, openThreshhold, 0f);
                        unlocked = false;
                    }
                }

            }
            else
            {

                if (unlocked)
                {
                    if (gameObject.transform.eulerAngles.y > openThreshhold)
                    {
                        gameObject.transform.Rotate(0, -50 * Time.deltaTime, 0);
                    }
                    else
                    {
                        gameObject.transform.eulerAngles = new Vector3(0f, openThreshhold, 0f);
                        unlocked = false;
                    }
                }
            }
        }
    }
}
