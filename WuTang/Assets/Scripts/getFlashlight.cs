using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFlashlight : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log(Vector3.Distance(Player.transform.position, this.transform.position) < 15);
            if (Vector3.Distance(Player.transform.position, this.transform.position) < 15)
            {
                this.transform.SetParent(Player.transform);
            }
        }
	}
}
