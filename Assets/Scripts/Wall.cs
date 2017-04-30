using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : PuzzleObject {

    private bool up;
    private Vector3 initialPos;
    public Light lt;
    private AudioSource aud;

    // Use this for initialization
    void Start () {
        up = false;
        initialPos = this.gameObject.transform.position;
        lt = lt.GetComponent<Light>();
        aud = GetComponentInParent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (up)
        {
            if (Vector3.Distance(initialPos, this.transform.position) < 34)
            {
                gameObject.transform.Translate(new Vector3(0f, 9.75f * Time.deltaTime, 0f));
            }

            lt.color = Color.green;
        }
        else if (!up)
        {
            if (Vector3.Distance(initialPos, this.transform.position) > 0.5)
            {
                if (!aud.isPlaying && aud != null)
                {
                    aud.Play();
                }
                gameObject.transform.Translate(new Vector3(0f, -9.75f * Time.deltaTime, 0f));
            }

            lt.color = Color.red;
        }
	}

    public override void activate()
    {
        if(up)
        {
            up = false;
        }
        else
        {
            up = true;
        }
    }
}
