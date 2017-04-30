using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : PuzzleObject
{
    private GameObject player;
    bool go = false;
    Vector3 oldPos;
    public PuzzleObject act;

    private Vector3 playerpos;
    private AudioSource aud;

    void Start()
    {
        player = GameObject.Find("Player");
        oldPos = gameObject.transform.position;
        aud = GetComponentInParent<AudioSource>();
    }


    public override void activate()
    {
        go = true;
        act.activate();
        aud.Play();
    }

        // Update is called once per frame
    void Update()
    {

        if (go && 0.5 > Vector3.Distance(oldPos, gameObject.transform.position))
        {
            gameObject.transform.Translate(new Vector3(-Time.deltaTime*2,0,0));
        }
    }
    
}
