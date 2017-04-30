using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : PuzzleObject {

    private bool on;
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponentInChildren<Light>().enabled = on;
	}

    public override void activate()
    {
        on = !on;
    }
}
