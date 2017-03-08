using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : PuzzleObject
{

    public GameObject playerpub;
    private Vector3 playerpos;
    bool unlocked =false;
    // Update is called once per frame

    public override void activate()
    {
        unlocked = true;
    }

    void Update ()
    {
        if (unlocked)
        {
            if (gameObject.transform.eulerAngles.y < 163f)
            {
                gameObject.transform.Rotate(0, 50 * Time.deltaTime, 0);
            }
            else
            {
                gameObject.transform.eulerAngles = new Vector3(0f, 163f, 0f);
                unlocked = false;
            }
        }
    }
}
