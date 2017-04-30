using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : PuzzleObject {

    public GameObject baseObject;
    private bool giveable = true;
    public PuzzleObject parent;
    public PuzzleObject act;
    public int items;
    public bool useX;
    private int current = 0;
    private int inHand = 0;
    private float move = -0.9f;
    private AudioSource aud;

    private void Start()
    {
        aud = GetComponentInParent<AudioSource>();
    }

    public override void activate()
    {
        giveable = true;
        inHand++;

        aud.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (giveable)
        {

            int loop = inHand;

            for (int i = 0; i < loop; i++)
            {
                GameObject spawned = GameObject.Instantiate(baseObject, parent.transform, true);
                if (useX)
                {
                    spawned.transform.Translate(new Vector3(move, 0f, 0f));
                }
                else
                {
                    spawned.transform.Translate(new Vector3(0f, 0f, move));
                }

                spawned.transform.parent = parent.transform;
                move = move - 0.8f;
                current++;
                inHand--;

                act.activate();
            }

            giveable = false;
        }
	}
}
