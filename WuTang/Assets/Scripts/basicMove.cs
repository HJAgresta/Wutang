using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void activate()
    {
        this.transform.Translate(0, 100, 0);
        Debug.Log("adfasdf");
    }

}
