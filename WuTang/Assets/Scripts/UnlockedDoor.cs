using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedDoor : MonoBehaviour {

    public GameObject playerpub;
    private Vector3 playerpos;
    // Update is called once per frame
    void Update()
    {
        playerpos = playerpub.transform.position;

        if (Vector3.Distance(playerpos, this.transform.position) < 20)
        {
            if (gameObject.transform.eulerAngles.y > 90f)
            {
                gameObject.transform.Rotate(0, -50 * Time.deltaTime, 0);
            }
            else
            {
                gameObject.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            }
        }
    }
}
