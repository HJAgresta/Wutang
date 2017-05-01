using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : followObject
{

    private AudioSource aud;

    void Start()
    {
        aud = GetComponentInParent<AudioSource>();
    }

    public override void activate()
    {
        if(aud != null)
        {
            aud.Play();
        }
    }
}
