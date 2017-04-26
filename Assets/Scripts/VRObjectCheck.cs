﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRObjectCheck : MonoBehaviour {

    private PuzzleObject puzz;
    public SteamVR_Controller left;
    public SteamVR_Controller right;
    private bool go;

	// Use this for initialization
	void Start () {
        go = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (go)
        {
            //puzz.activate();
            Debug.Log("Hey");
            go = false;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PuzzleObject>() != null)
        {
            go = true;
            puzz = other.GetComponent<PuzzleObject>();
        }
            
    }
}
