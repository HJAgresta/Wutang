using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : PuzzleObject
{
    public GameObject playerpub;
    bool go = false;
    Vector3 oldPos;
    public PuzzleObject act;

    private Vector3 playerpos;

    void Start()
    {
        oldPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerpos = playerpub.transform.position;

        if (Input.GetKeyDown("e") && Vector3.Distance(playerpos, this.transform.position) < 19)
        {
            go = true;
            act.activate();
        }

        if (go && 0.5 > Vector3.Distance(oldPos, gameObject.transform.position))
        {
            gameObject.transform.Translate(new Vector3(-Time.deltaTime*2,0,0));
        }
    }
}
