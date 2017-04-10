using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePlatform : PuzzleObject {
    public PuzzleObject act;
    private bool go = false;
    private Vector3 oldPos;

    void Start()
    {
        oldPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (go && 0.5 > Vector3.Distance(oldPos, gameObject.transform.position))
        {
            gameObject.transform.Translate(new Vector3(0, Time.deltaTime * .1f, 0));
            act.activate();
        }
	}

    public override void activate()
    {
        go = true;
    }
}