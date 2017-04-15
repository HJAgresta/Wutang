using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : PuzzleObject {

    public GameObject playerpub;
    private Vector3 playerpos;
    public PuzzleObject act;
    private bool move;
    private AudioSource aud;
    private bool active = false;

    // Use this for initialization
    void Start () {
        move = false;
        aud = GetComponentInParent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        playerpos = playerpub.transform.position;

        if (Vector3.Distance(playerpos, this.transform.position) < 19)
        {
            //push e to move the painting
            if (!active && Input.GetKeyDown("e"))
            {
                move = true;
            }
        }

        if (move)
        {
            if (this.transform.position.y > -28.2)
            {
                gameObject.transform.Translate(new Vector3(0f, 15f * Time.deltaTime, 0f));
            }
            else
            {
                aud.Play();
                activate();
                move = false;
                active = true;
            }
        }
    }

    public override void activate()
    {
        act.activate();
    }
}
