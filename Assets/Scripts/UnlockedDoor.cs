using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class UnlockedDoor : PuzzleObject {
 
    // Update is called once per frame
    bool unlocked = false;
    public float openThreshhold;
    private bool lessthan = false;
    public bool clockwise = true;
    private AudioSource aud;
    public AudioClip door;

    public override void activate()
    {
        unlocked = true;
        aud.clip = door; // Change back to door sound
        aud.Play();
    }
    void Start()
    {
        if (gameObject.transform.eulerAngles.y < openThreshhold)
        {
            lessthan = true;
        }
        aud = GetComponentInParent<AudioSource>();
    }
    void Update()
    {
        //aud.Play(); // Play the jiggle sound

        if (lessthan && unlocked)
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
