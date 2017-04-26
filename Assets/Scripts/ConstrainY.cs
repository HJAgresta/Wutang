using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainY : MonoBehaviour {

    public GameObject area;
    private float yValue;

	// Use this for initialization
	void Start () {
        yValue = area.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (area.transform.position.y != yValue)
        {
            area.transform.position = new Vector3(area.transform.position.x, yValue, area.transform.position.z);
        }
	}
}
