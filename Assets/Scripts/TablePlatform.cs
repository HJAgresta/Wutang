using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePlatform : PuzzleObject {
    private bool go = false;
    private Vector3 oldPos;
    private AudioSource aud;

    void Start()
    {
        oldPos = gameObject.transform.position;
        aud = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (go && 0.5 > Vector3.Distance(oldPos, gameObject.transform.position))
        {
            if (!aud.isPlaying && aud != null)
            {
                aud.Play();
            }
            gameObject.transform.Translate(new Vector3(0, Time.deltaTime * .1f, 0));
        }
	}

    public override void activate()
    {
        go = true;
    }
}