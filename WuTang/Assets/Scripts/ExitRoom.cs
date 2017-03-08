using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRoom : MonoBehaviour {

    private int roomCount;
    public GameObject playerpub;
    public GameObject key;
    public GameObject door;
    private Vector3 playerpos;

	// Use this for initialization
	void Start () {
        roomCount = 1;
	}
	
	// Update is called once per frame
	void Update () {
        playerpos = playerpub.transform.position;
        
 
        
        //check if player left the room they are on
        if(playerpos.x < -50)
        {
            if(roomCount == 1)
            {
                roomCount++;
            }
        }
	}

}
