using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : PuzzleObject
{
    //moves any item in the positive Z axis

    bool go = false;
    float oldPos;
    public PuzzleObject act;
    public int dist;

    public override void activate()
    {
        go = true;
    }

    void Start()
    {
        oldPos = gameObject.transform.position.z;
        dist = Mathf.Abs(dist);
    }
    // Update is called once per frame
    void Update()
    {
        if (go && dist > Mathf.Abs(oldPos - gameObject.transform.position.z))
        {
            gameObject.transform.Translate(new Vector3(0, 0, Time.deltaTime*10));
            act.activate();
        }
    }
}
