using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : PuzzleObject {

    private bool active;
    public PuzzleObject act;
    public GameObject player;

	// Use this for initialization
	void Start () {
        active = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (active && Input.GetKeyDown("e") && Vector3.Distance(player.transform.position, this.transform.position) < 15)
        {
            act.activate();
        }
	}

    public override void activate()
    {
        active = true;
    }
}
