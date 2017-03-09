using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDesk : PuzzleObject
{
    bool go = false;
    float oldPos;
    bool next = false;
    public PuzzleObject act;

    public override void activate()
    {
        go = true;
    }

    void Start()
    {
        oldPos = gameObject.transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        if (go && 5 > Mathf.Abs(oldPos - gameObject.transform.position.z))
        {
            gameObject.transform.Translate(new Vector3(0, 0, -Time.deltaTime * 10));
        }
        else if (next == false)
        {
            next = true;
        }

        if (next)
        {
            act.activate();
        }
    }
}