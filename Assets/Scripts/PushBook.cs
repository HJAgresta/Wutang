using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBook : PuzzleObject {
    
    private Vector3 initialpos;
    private bool move;
    private bool active;
    public PuzzleObject act;
    public bool PositiveZ;
    private Vector3 direction;
    private AudioSource aud;

    // Use this for initialization
    void Start()
    {
        initialpos = this.transform.position;
        move = false;
        active = true;
        if(PositiveZ)
        {
            direction = new Vector3(0, 0, 1);
        }
        else
        {
            direction = new Vector3(0, 0, -1);
        }
        aud = GetComponentInParent<AudioSource>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (move && Vector3.Distance(initialpos, this.transform.position) < 1)
        {

            this.transform.Translate(direction * Time.deltaTime, Space.World);
            activate();
        }
        else if (move)
        {
            move = false;
        }
    }

    public override void activate()
    {
        move = true;
        aud.Play();
        if (active)
        {
            act.activate();
            active = false;
        }
    }
}