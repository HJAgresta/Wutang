using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumUnlock : PuzzleObject {
    public int steps;
    public PuzzleObject act;
    private int counter;

    // Use this for initialization
    void Start () {
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(counter == steps)
        {
            act.activate();
        }
	}

    public override void activate()
    {
        counter++;
    }
}
