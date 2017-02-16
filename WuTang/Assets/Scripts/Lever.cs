using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public GameObject playerpub;
    private Vector3 playerpos;
    public Animation ani;
    public GameObject act;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        playerpos = playerpub.transform.position;

        if (GameObject.Find("lever") && Vector3.Distance(playerpos, this.transform.position) < 10)
        {
            //push e to pick up key
            if (Input.GetKeyDown("e"))
            {

                Debug.Log("lever flip");
                ani.Play();
                act.GetComponent<basicMove>().activate();
            }
        }
    }
}
