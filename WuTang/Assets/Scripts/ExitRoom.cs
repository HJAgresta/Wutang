using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRoom : MonoBehaviour {

    private int roomCount;
    public GameObject playerpub;
    public GameObject key;
    public GameObject door;
    private Vector3 playerpos;
    private bool hasKey;

	// Use this for initialization
	void Start () {
        hasKey = false;
        roomCount = 1;
	}
	
	// Update is called once per frame
	void Update () {
        playerpos = playerpub.transform.position;

        //pickup key check
        if (GameObject.Find("Key") && Vector3.Distance(playerpos, key.transform.position) < 10)
        {
            //push e to pick up key
            if (Input.GetKeyDown("e"))
            {
                hasKey = true;
                Debug.Log("Aquired Key");
                DestroyObject(key);
            }
        }


        //open door check
        //door will move to side when run into
        if (hasKey && Vector3.Distance(playerpos, door.transform.position) < 30)
        {
            if (door.transform.eulerAngles.y < 163f)
            {
                door.transform.Rotate(0, 50 * Time.deltaTime, 0);
            }
            else
            {
                door.transform.eulerAngles = new Vector3(0f, 163f, 0f);
            }
        }
        
        //check if player left the room they are on
        if(playerpos.x < -50)
        {
            if(roomCount == 1)
            {
                resetRoom();
                roomCount++;
            }
        }
	}

    public void resetRoom()
    {
        hasKey = false;
    }
}
