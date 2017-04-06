using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrue : PuzzleObject {

    public GameObject player;
    private Vector3 initialpos;
    private bool move;
    private bool active;
    public PuzzleObject act;

    // Use this for initialization
    void Start()
    {
        initialpos = this.transform.position;
        move = false;
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 11 && Input.GetKeyDown("e"))
        {
            move = true;
        }

        if (move && 1 > Mathf.Abs(initialpos.y - gameObject.transform.position.y))
        {
            this.transform.Translate(new Vector3(0f, -Time.deltaTime, 0f));
            activate();
        }
    }

    public override void activate()
    {
        if (active)
        {
            act.activate();
            active = false;
        }
    }
}

