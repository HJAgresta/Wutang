using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : PuzzleObject {

    private GameObject player;
    public PuzzleObject act;
    private AudioSource aud;

    private void Start()
    {
        player = GameObject.Find("Player");
        aud = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 14)
        {
            //push e to pick up key
            if (Input.GetKeyDown("e"))
            {
                act.activate();
                Destroy(gameObject, .2f);
                if (aud != null)
                {
                    aud.Play();
                }
            }
        }
    }
}
