using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDesk : PuzzleObject
{
    //moves any item in the negative Z axis

    bool go = false;
    Vector3 oldPos;
    public PuzzleObject act;
    public float dist;

    public override void activate()
    {
        go = true; 
    }

    void Start()
    {
        oldPos = gameObject.transform.position;
    }
    // Update is called once per frame

    void Update()
    {
        if (go && dist > Vector3.Distance(oldPos, gameObject.transform.position))
        {
            gameObject.transform.Translate(new Vector3(0, 0, -Time.deltaTime * 10));
            act.activate();
        }
    }
}