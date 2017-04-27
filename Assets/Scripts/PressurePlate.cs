using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : PuzzleObject {

    private GameObject player;
    private Vector3 initialpos;
    private bool move;

	// Use this for initialization
	void Start () {
        initialpos = this.transform.position;
        move = false;
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (move && 1 > Mathf.Abs(initialpos.y - gameObject.transform.position.y))
        {
            this.transform.Translate(new Vector3(0f, -Time.deltaTime, 0f));
        }

        if(1 < Mathf.Abs(initialpos.y - gameObject.transform.position.y))
        {
            reset();
        }
	}

    public override void activate()
    {
        move = true;
    }

    void reset()
    {
        move = false;
        this.transform.position = initialpos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<CapsuleCollider>())
        {
            Debug.Log("Yo");
            activate();
        }
    }
}
