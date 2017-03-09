using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedDoor : MonoBehaviour {

    public GameObject playerpub;
    private Vector3 playerpos;
    private bool opening = false;
    private Vector3 vec;
    private Vector3 endVec = new Vector3(0f, 270f, 0f);

    // Update is called once per frame
    void Update()
    {
        playerpos = playerpub.transform.position;

        if (Vector3.Distance(playerpos, this.transform.position) < 20 && Input.GetKeyDown("e"))
        {
            opening = true;
        }

        if (opening)
        {
            vec = Vector3.Lerp(vec, endVec, Time.deltaTime * 50);
            this.transform.eulerAngles = vec;
        }
    }
}
