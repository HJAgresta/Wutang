using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : PuzzleObject {

    //pushes down a button

    public GameObject playerpub;
    bool go = false;
    float oldPos;
    public PuzzleObject act;
    public float dist;
    private Vector3 playerpos;

    void Start()
    {
        oldPos = gameObject.transform.position.y;
        dist = Mathf.Abs(dist);
    }
    // Update is called once per frame

    void Update()
    {
        playerpos = playerpub.transform.position;

        if (go && dist > Mathf.Abs(oldPos - gameObject.transform.position.y))
        {
            gameObject.transform.Translate(new Vector3(0, -Time.deltaTime * 3, 0));
            act.activate();
        }
        else if (!go && 0.05 < Mathf.Abs(oldPos - gameObject.transform.position.y))
        {
            gameObject.transform.Translate(new Vector3(0, Time.deltaTime * 3, 0));
        }

        if(dist <= Mathf.Abs(oldPos - gameObject.transform.position.y))
        {
            popUp();
        }

        if (Input.GetKeyDown("e") && Vector3.Distance(playerpos, this.transform.position) < 10)
        {
            go = true;
        }
    }

    void popUp()
    {
        go = false;
    }
}