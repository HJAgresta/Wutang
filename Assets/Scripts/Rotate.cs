using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : PuzzleObject {

    public PuzzleObject act;
    private bool go;

	// Use this for initialization
	void Start () {
        go = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (go && this.transform.eulerAngles.x < 89)
        {
            Debug.Log(this.transform.eulerAngles.x);
            this.transform.Rotate(Time.deltaTime * 30, 0f, 0f);
        }
        else if(go && this.transform.eulerAngles.x >= 89)
        {
            act.activate();
        }
	}

    public override void activate()
    {
        go = true;
    }
}
