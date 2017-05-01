using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : PuzzleObject {

    public GameObject baseObject;
    public PuzzleObject parent;
    public PuzzleObject act;
    public bool useX;
    private float move = -0.9f;
    private AudioSource aud;
    private GameObject playerpub;
    private bool go;
    private GameObject takeItem;

    private void Start()
    {
        aud = GetComponentInParent<AudioSource>();
        go = false;
    }

    public override void activate()
    {
        //desktop
        playerpub = GameObject.FindGameObjectWithTag("Player");
        if (playerpub.GetComponentsInChildren<TakeItem>() != null)
        {
            takeItem = playerpub.GetComponentInChildren<TakeItem>().gameObject;
            if(aud !=null)
            {
                aud.Play();
            }
            playerpub.GetComponent<Inventory>().emptyInventory();
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

            act.activate();
            Destroy(takeItem);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TakeItem>() != null)
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

            act.activate();

            other.gameObject.SetActive(false);
            other.GetComponent<MeshRenderer>().enabled = false;
            //Destroy(other.gameObject);
        }
    }
}
