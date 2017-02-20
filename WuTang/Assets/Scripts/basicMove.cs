using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMove : PuzzleObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void activate()
    {
        this.transform.Translate(0, 100, 0);
    }

}
