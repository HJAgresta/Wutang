using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Door : PuzzleObject
{
    private GameObject playerpub;
    [System.NonSerialized]public bool unlocked = false;
    public float openThreshhold;
    private bool lessthan = false;
    public bool clockwise = true;
    private AudioSource aud;
    public AudioClip door;

    public override void activate()
    {

        Debug.Log("door");
        playerpub = GameObject.FindGameObjectWithTag("Player");
        if (playerpub.GetComponentInChildren<Key>() != null)
        {

            GameObject key = playerpub.GetComponentInChildren<Key>().gameObject;
            unlocked = true;
            aud.clip = door; // Change back to door sound
            aud.Play();
            playerpub.GetComponent<Inventory>().emptyInventory();

            Destroy(key);
        }
        if(gameObject.GetComponentInParent<NumUnlock>()!=null)
        {
            if(gameObject.GetComponentInParent<NumUnlock>().ready)
            {
                unlocked = true;
                aud.clip = door; // Change back to door sound
                aud.Play();
            }
        }
    }
    void Start ()
    {
        
        aud = GetComponentInParent<AudioSource>();

        if (gameObject.transform.eulerAngles.y < openThreshhold)
        {
            lessthan = true;
        }
    }
    void Update ()
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

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Key>() != null)
        {
            activate();
            
        }
    }
}
