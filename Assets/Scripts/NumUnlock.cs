using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumUnlock : PuzzleObject {
    public int steps;
    public PuzzleObject act;
    private int counter = 0;
    [System.NonSerialized]
    public bool ready = false;

    public override void activate()
    {
        Debug.Log("num");
        counter++;

        if (counter == steps)
        {
            ready = true;
            act.activate();
        }
    }
}
