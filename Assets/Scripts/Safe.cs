using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : PuzzleObject {

    public GameObject hinge;
    private bool unlocked;

	// Use this for initialization
	void Start () {
        unlocked = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (unlocked)
        {
            if (this.transform.eulerAngles.y > 180)
            {
                this.transform.RotateAround(hinge.transform.position, Vector3.up, -Time.deltaTime * 30);
            }
        }
	}

    public override void activate()
    {
        unlocked = true;
    }
}
