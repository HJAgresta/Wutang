using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFlashlight : PuzzleObject {

    public GameObject Player;
    private AudioSource aud;
    private bool poss = false;

    private void Start()
    {
        aud = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        
        if (poss)
        {
            this.transform.position = Player.transform.position;
            this.transform.rotation = Player.transform.rotation;
            this.transform.SetParent(Player.transform);
            this.transform.Rotate(0, 180, 0);
            this.transform.Translate(-2, -1, 0);
            aud.Play();
            poss = false;
        }
	}

    public override void activate()
    {
        if(Vector3.Distance(Player.transform.position, this.transform.position) < 15)
        {
            poss = true;
        }
    }
}
