using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : PuzzleObject {
    
    public PuzzleObject act;
    private bool move;
    private AudioSource aud;
    private bool active = false;

    // Use this for initialization
    void Start () {
        move = false;
        aud = GetComponentInParent<AudioSource>();
    }
	
    public override void activate()
    {
        if(!active)
        {
            move = true;
        }
    }
	// Update is called once per frame
	void Update () {
        

        if (move)
        {
            if (this.transform.position.y > -28.2)
            {
                gameObject.transform.Translate(new Vector3(0f, 15f * Time.deltaTime, 0f));
            }
            else
            {
                //aud.Play();
                act.activate();
                this.enabled = false;
                
            }
        }
    }
    
}
