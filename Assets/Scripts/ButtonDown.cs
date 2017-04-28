using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : PuzzleObject {

    //pushes down a button
    
    bool go = false;
    float oldPos;
    public PuzzleObject act;
    public PuzzleObject act2;
    public float dist;
    private AudioSource aud;

    void Start()
    {
        oldPos = gameObject.transform.position.y;
        dist = Mathf.Abs(dist);
        aud = GetComponentInParent<AudioSource>();
    }
    // Update is called once per frame

    void Update()
    {

        if (go && dist > Mathf.Abs(oldPos - gameObject.transform.position.y))
        {
            gameObject.transform.Translate(new Vector3(0, -Time.deltaTime * 3, 0));
            
        }
        else if (!go && 0.05 < Mathf.Abs(oldPos - gameObject.transform.position.y))
        {
            gameObject.transform.Translate(new Vector3(0, Time.deltaTime * 3, 0));
        }

        if(this.transform.position.y > oldPos + 0.1f)
        {
            gameObject.transform.Translate(new Vector3(0f, -.5f, 0f));
        }

        if(dist <= Mathf.Abs(oldPos - gameObject.transform.position.y))
        {
            popUp();
        }
<<<<<<< HEAD
    }

    void popUp()
=======
        
    }


    public override void activate()
    {
        go = true;
        act.activate();
        aud.Play();

    }

        void popUp()
>>>>>>> origin/master
    {
        go = false;
    }

    public override void activate()
    {
        go = true;
        act.activate();
        if(act2 != null)
        {
            act2.activate();
        }
        aud.Play();
    }
}