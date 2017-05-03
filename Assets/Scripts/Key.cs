using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : followObject
{
    private AudioSource aud;

    void Start()
    {
        aud = GetComponentInParent<AudioSource>();
    }

    public override void activate()
    {
        aud.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Door>()!= null)
        {
            other.gameObject.GetComponent<Door>().activate();
            if(GameObject.Find("Player").GetComponent<Inventory>() != null)
            {
                GameObject.Find("Player").GetComponent<Inventory>().emptyInventory();
            }
            //Destroy(gameObject);
        }
    }
}
