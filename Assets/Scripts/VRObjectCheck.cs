using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRObjectCheck : MonoBehaviour {

    private PuzzleObject puzz;
    public SteamVR_Controller left;
    public SteamVR_Controller right;
    private bool go;
    public bool triggerClicked;
    private bool trigPrevClicked;
    private bool holdingItem;

	// Use this for initialization
	void Start () {
        go = false;
        trigPrevClicked = false;
        holdingItem = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (go)
        {
            puzz.activate();

            if(puzz.GetComponent<Key>() != null)
            {
                puzz.GetComponent<Rigidbody>().useGravity = false;
                puzz.GetComponent<Rigidbody>().freezeRotation = false;
                puzz.transform.parent = null;
                if(puzz.GetComponent<Collider>() != null)
                {
                    puzz.GetComponent<Collider>().isTrigger = true;
                }
                holdingItem = true;      
            }
            else if(puzz.GetComponent<TakeItem>() != null)
            {
                puzz.GetComponent<Rigidbody>().useGravity = false;
                puzz.transform.parent = null;
                if (puzz.GetComponent<Collider>() != null)
                {
                    puzz.GetComponent<Collider>().isTrigger = true;
                }
                holdingItem = true;
            }
            
            go = false;
        }


        if(holdingItem && !triggerClicked)
        {
            if (puzz != null)
            {
                if (puzz.GetComponent<Key>() != null || puzz.GetComponent<TakeItem>() != null)
                {
                    puzz.GetComponent<Rigidbody>().useGravity = true;
                    if (puzz.GetComponent<Collider>() != null)
                    {
                        puzz.GetComponent<Collider>().isTrigger = false;
                    }
                }
            }

            holdingItem = false;
        }

        if (!triggerClicked)
        {
            trigPrevClicked = false;
        }
	}

    void OnTriggerStay(Collider other)
    { 
        if (other.GetComponent<PuzzleObject>() != null && other.GetComponent<PuzzleObject>().interactable && triggerClicked && !trigPrevClicked)
        {
            trigPrevClicked = true;
            go = true;
            puzz = other.GetComponent<PuzzleObject>();
        }
    }
}
