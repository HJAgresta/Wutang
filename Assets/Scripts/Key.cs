using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PuzzleObject
{
    public GameObject playerpub;
    private Vector3 playerpos;
    public PuzzleObject act;
    bool pickable = false;

    public override void activate()
    {
        pickable = true;
    }

    // Update is called once per frame
    void Update ()
    {
        playerpos = playerpub.transform.position;


        if (Vector3.Distance(playerpos, this.transform.position) < 19)
        {
            //push e to pick up key
            if (Input.GetKeyDown("e") && pickable)
            {
                act.activate();
                Destroy(gameObject);
            }
        }
    }
}
