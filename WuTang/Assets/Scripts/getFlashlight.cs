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
            if (Vector3.Distance(Player.transform.position, this.transform.position) < 15)
            {
                this.transform.position = Player.transform.position;
                this.transform.rotation = Player.transform.rotation;
                this.transform.SetParent(Player.transform);
                this.transform.Rotate(0, 180, 0);
                this.transform.Translate(-3, 5, -2);
            }
        }
	}
}
