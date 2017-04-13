using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : PuzzleObject {

    public GameObject playerpub;
    public PuzzleObject act;


    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(playerpub.transform.position, this.transform.position) < 10)
        {
            //push e to pick up key
            if (Input.GetKeyDown("e"))
            {
                act.activate();
                Destroy(gameObject);
            }
        }
    }
}
