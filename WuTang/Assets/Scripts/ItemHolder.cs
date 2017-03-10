using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : PuzzleObject {

    public GameObject knife;
    public GameObject playerpub;
    private bool giveable = true;
    public PuzzleObject act;
    private int items = 3;
    private int current = 0;
    private int inHand = 0;

    public override void activate()
    {
        giveable = true;
        inHand++;
    }
	
	// Update is called once per frame
	void Update () {
        if (giveable && Vector3.Distance(playerpub.transform.position, this.transform.position) < 19 && Input.GetKeyDown("e"))
        {
            int loop = inHand;

            for(int i = 0; i < loop; i++)
            {
                Debug.Log("blech");

                GameObject.Instantiate(knife, new Vector3((.6f * (current + 1)),  0, 0), new Quaternion(0, 0, 0, 0), GameObject.Find("Kitchen").transform);
                current++;
                inHand--;

                if(current == items)
                {
                    act.activate();
                }
            }
        }
	}
}
