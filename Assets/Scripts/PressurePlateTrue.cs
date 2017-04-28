using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrue : PuzzleObject {

    private GameObject player;
    private Vector3 initialpos;
    private bool move;
    private bool active;
    public PuzzleObject act;

    // Use this for initialization
    void Start()
    {
        initialpos = this.transform.position;
        move = false;
        active = true;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (move && 1 > Mathf.Abs(initialpos.y - gameObject.transform.position.y))
        {
            this.transform.Translate(new Vector3(0f, -Time.deltaTime, 0f));
            activate();
        }
    }

    public override void activate()
    {
        move = true;

        if (active)
        {
            act.activate();
            active = false;
        }
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

