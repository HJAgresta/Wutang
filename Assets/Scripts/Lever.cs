using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : PuzzleObject{

    public GameObject playerpub;
    private Vector3 playerpos;
    public Animation ani;
    public PuzzleObject act;
    public bool active;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        playerpos = playerpub.transform.position;


        if (Vector3.Distance(playerpos, this.transform.position) < 19)
        {
            //push e to pick up key
            if (Input.GetKeyDown("e"))
            {
                if(active)
                {
                    ani.Play();
                    act.activate();
                }
            }
        }
    }

    public override void activate()
    {
                active = true;
    }
}
