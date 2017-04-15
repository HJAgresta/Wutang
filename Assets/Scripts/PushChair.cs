using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushChair : PuzzleObject {

    public GameObject playerpub;
    bool go = false;
    public PuzzleObject act;
    private Vector3 playerpos;
    public float max;
    public float min;
    private AudioSource aud;
    private bool active = true;

    private void Start()
    {
        aud = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        playerpos = playerpub.transform.position;

        if (active && Input.GetKeyDown("e") && Vector3.Distance(playerpos, this.transform.position) < 15)
        {
            active = false;
            go = true;
            act.activate();
            aud.Play();
        }

        if (go && this.transform.position.x > max)
        {
            gameObject.transform.Translate(new Vector3(-Time.deltaTime * 10, 0, 0));
        }
        else if(go && this.transform.position.x < min)
        {
            gameObject.transform.Translate(new Vector3(Time.deltaTime * -10, 0, 0));
        }
        else if (go)
        {
            go = false;
        }
    }
}
