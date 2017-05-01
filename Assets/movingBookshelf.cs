using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBookshelf : PuzzleObject {

    //moves any item in the positive Z axis

    public GameObject baseObject;
    public PuzzleObject parent;
    public bool useX;
    private float move = -0.9f;
    private AudioSource aud;
    private GameObject playerpub;

    bool go = false;
    float oldPos;
    public int dist;

    public int steps;
    private int counter = 0;


    public override void activate()
    {
        playerpub = GameObject.FindGameObjectWithTag("Player");
        if (playerpub.GetComponentInChildren<TakeItem>() != null)
        {
            GameObject takeItem = playerpub.GetComponentInChildren<TakeItem>().gameObject;
            if (aud != null)
            {
                aud.Play();
            }
            GameObject spawned = GameObject.Instantiate(baseObject, parent.transform, true);
            if (useX)
            {
                spawned.transform.Translate(new Vector3(move, 0f, 0f));
            }
            else
            {
                spawned.transform.Translate(new Vector3(0f, 0f, move));
            }

            counter++;
            spawned.transform.parent = parent.transform;
            move = move - 0.8f;

            if (counter == steps)
            {
                go = true;
            }
            playerpub.GetComponent<Inventory>().emptyInventory();
            Destroy(takeItem);
        }

    }



    void Start()
    {
        oldPos = gameObject.transform.position.z;
        dist = Mathf.Abs(dist);
    }
    // Update is called once per frame
    void Update()
    {
        if (go && dist > Mathf.Abs(oldPos - gameObject.transform.position.z))
        {
            gameObject.transform.Translate(new Vector3(0, 0, Time.deltaTime * 10));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TakeItem>() != null)
        {
            if (aud != null)
            {
                aud.Play();
            }

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

            other.GetComponent<MeshRenderer>().enabled = false;
            Destroy(other.gameObject);

            counter++;

            if (counter == steps)
            {
                go = true;
            }
        }
    }
}
