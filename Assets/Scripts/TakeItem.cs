using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : PuzzleObject {
    
    public PuzzleObject act;
    private AudioSource aud;

    private void Start()
    {
        aud = GetComponentInParent<AudioSource>();
    }

    public override void activate()
    {
        act.activate();
        Destroy(gameObject, .2f);
        if (aud != null)
        {
            aud.Play();
        }
    }
}
