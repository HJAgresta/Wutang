using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : PuzzleObject
{
    
    public AudioClip fire;

    public NumUnlock act;
    private GameObject playerpub;
    private GameObject player;
    private AudioSource aud;
    private bool lit;
    private bool active;

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
        playerpub = GameObject.FindGameObjectWithTag("Player");
        if (playerpub.GetComponentInChildren<TakeItem>() != null)
        {
            
            GameObject takeItem = playerpub.GetComponentInChildren<TakeItem>().gameObject;
            aud.Play();
            playerpub.GetComponent<Inventory>().emptyInventory();
            act.activate();
            Destroy(takeItem);
        }
    }
}
