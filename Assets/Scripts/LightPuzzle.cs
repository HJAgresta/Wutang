using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzle : MonoBehaviour {

    public Light l1;
    public Light l2;
    public Light l3;
    public Light l4;
    public Light l5;
    public Light l6;
    public Light l7;
    public PuzzleObject act;

	// Use this for initialization
	void Start () {
        l1 = l1.GetComponent<Light>();
        l2 = l2.GetComponent<Light>();
        l3 = l3.GetComponent<Light>();
        l4 = l4.GetComponent<Light>();
        l5 = l5.GetComponent<Light>();
        l6 = l6.GetComponent<Light>();
        l7 = l7.GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        //check for correct lights
        if(!l1.enabled && l2.enabled && !l3.enabled && l4.enabled && l5.enabled && !l6.enabled && l7.enabled)
        {
            act.activate();
        }
	}
}
