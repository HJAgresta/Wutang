using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : PuzzleObject {

    //pushes down a button

    private GameObject player;
    bool go = false;
    float oldPos;
    public PuzzleObject act;
    public PuzzleObject act2;
    public float dist;
    private Vector3 playerpos;
    private AudioSource aud;

    void Start()
    {
        player = GameObject.Find("Player");
        oldPos = gameObject.transform.position.y;
        dist = Mathf.Abs(dist);
        aud = GetComponentInParent<AudioSource>();
    }
    // Update is called once per frame

    void Update()
    {
        playerpos = player.transform.position;

        if (go && dist > Mathf.Abs(oldPos - gameObject.transform.position.y))
        {
            gameObject.transform.Translate(new Vector3(0, -Time.deltaTime * 3, 0));
            
        }
        else if (!go && 0.05 < Mathf.Abs(oldPos - gameObject.transform.position.y))
        {
            gameObject.transform.Translate(new Vector3(0, Time.deltaTime * 3, 0));
        }

        if(this.transform.position.y > oldPos + 0.1f)
        {
            gameObject.transform.Translate(new Vector3(0f, -.5f, 0f));
        }

        if(dist <= Mathf.Abs(oldPos - gameObject.transform.position.y))
        {
            popUp();
        }
    }

    void popUp()
    {
        go = false;
    }

    public override void activate()
    {
        go = true;
        act.activate();
        if(act2 != null)
        {
            act2.activate();
        }
        aud.Play();
    }
}