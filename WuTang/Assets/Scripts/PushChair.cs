using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushChair : PuzzleObject {

    public GameObject playerpub;
    bool go = false;
    public PuzzleObject act;
    private Vector3 playerpos;
    public float max;
    public float min;

    // Update is called once per frame
    void Update () {
        playerpos = playerpub.transform.position;

        if (Input.GetKeyDown("e") && Vector3.Distance(playerpos, this.transform.position) < 15)
        {
            go = true;
            act.activate();
        }

        if (this.transform.position.x > max && go)
        {
            gameObject.transform.Translate(new Vector3(-Time.deltaTime * 10, 0, 0));
        }
        else if(this.transform.position.x < min && go)
        {
            gameObject.transform.Translate(new Vector3(Time.deltaTime * -10, 0, 0));
        }
    }
}
