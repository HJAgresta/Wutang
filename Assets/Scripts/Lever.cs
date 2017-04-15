using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : PuzzleObject{

    public GameObject playerpub;
    private Vector3 playerpos;
    public Animation ani;
    public PuzzleObject act;
    public bool active;
    private AudioSource aud;

    // Use this for initialization
    void Start () {
        aud = GetComponentInParent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        playerpos = playerpub.transform.position;


        if (active && Vector3.Distance(playerpos, this.transform.position) < 19 && Input.GetKeyDown("e"))
        {
            ani.Play();
            aud.Play();
            active = false;
        }
    }

    public override void activate()
    {
        active = false;
    }
}
