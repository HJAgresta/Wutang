using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDoor : PuzzleObject {

    public PuzzleObject act1;
    public PuzzleObject act2;
    public PuzzleObject act3;
    private int num = 1000;
    private bool unlock = false;
	
	// Update is called once per frame
	void Update () {
		if(num == 0)
        {
            act1.activate();
        }
        else if (num == 1)
        {
            act2.activate();
        }
        else if (num == 2)
        {
            act3.activate();
        }
    }

    public override void activate()
    {
        if (!unlock)
        {
            num = Random.Range(0, 2);
        }
    }
}
