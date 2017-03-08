using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : PuzzleObject {

    public GameObject playerpub;
    private Vector3 playerpos;
    public PuzzleObject act;
    private bool move;

    // Use this for initialization
    void Start () {
        move = false;
	}
	
	// Update is called once per frame
	void Update () {
        playerpos = playerpub.transform.position;

        if (Vector3.Distance(playerpos, this.transform.position) < 19)
        {
            //push e to move the painting
            if (Input.GetKeyDown("e"))
            {
                move = true;
            }
        }

        if (move)
        {
            if (this.transform.position.y > -28.2)
            {
                gameObject.transform.Translate(new Vector3(0f, -9.75f * Time.deltaTime, 0f));
            }
            else
            {
                activate();
            }
        }
    }

    public override void activate()
    {
        act.activate();
    }
}
