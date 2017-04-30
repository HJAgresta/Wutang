using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : PuzzleObject {

    private bool active;
    public PuzzleObject act;
    private GameObject player;
    private AudioSource aud;
    private bool lit;
    public AudioClip fire;

    // Use this for initialization
    void Start()
    {
        lit = false;
        active = false;
        player = GameObject.Find("Player");
        aud = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active && Input.GetKeyDown("e") && Vector3.Distance(player.transform.position, this.transform.position) < 15)
        {
            act.activate();
        }
        if (active && lit && !aud.isPlaying && aud != null)
        {
            aud.Play();
        }
        else if (active && !aud.isPlaying)
        {
            aud.clip = fire;
        }
    }

    public override void activate()
    {
        active = true;
    }
}
