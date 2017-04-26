using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : PuzzleObject{

    public Animation ani;
    public PuzzleObject act;
    private AudioSource aud;
    private bool activated = false;

    // Use this for initialization
    void Start () {
        aud = GetComponentInParent<AudioSource>();
    }

    public override void activate()
    {
        if(!activated)
        {
            ani.Play();
            aud.Play();
            act.activate();
        }
    }
}
