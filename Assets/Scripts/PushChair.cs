using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushChair : PuzzleObject {
    
    bool go = false;
    public PuzzleObject act;
    public float max;
    public float min;
    private AudioSource aud;
    private bool active = true;

    private void Start()
    {
        aud = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    public override void activate()
    {
        if (active)
        {
            active = false;
            go = true;
            act.activate();
            if (aud != null)
            {
                aud.Play();
            }
        }
    }

    void Update()
    { 
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
