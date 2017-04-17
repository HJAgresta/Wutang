using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Door : PuzzleObject
{
    public GameObject playerpub;
    bool unlocked = false;
    public float openThreshhold;
    private bool lessthan = false;
    public bool clockwise = true;

    public override void activate()
    {
        if(playerpub.GetComponentInChildren<Key>()!=null)
        {
            unlocked = true;
            GameObject key = playerpub.GetComponentInChildren<Key>().gameObject;
            playerpub.GetComponentInChildren<Inventory>().emptyInventory();
            Destroy(key);
        }
    }
    void Start ()
    {
        playerpub = GameObject.FindGameObjectWithTag("Player");

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
