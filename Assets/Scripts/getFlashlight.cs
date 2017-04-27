using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFlashlight : PuzzleObject {

    private GameObject player;
    private AudioSource aud;
    private bool poss = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        aud = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        
        if (poss)
        {
            this.transform.position = player.transform.position;
            this.transform.rotation = player.transform.rotation;
            this.transform.SetParent(player.transform);
            this.transform.Rotate(0, 180, 0);
            this.transform.Translate(-2, -1, 0);
            aud.Play();
            poss = false;
        }
	}

    public override void activate()
    {
        if(Vector3.Distance(player.transform.position, this.transform.position) < 15)
        {
            poss = true;
        }
    }
}
