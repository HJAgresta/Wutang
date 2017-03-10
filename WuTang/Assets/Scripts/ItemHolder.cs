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
    private float move = -0.9f;
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
                GameObject spawned = GameObject.Instantiate(knife, GameObject.Find("KnifeHolder").transform, true);
                spawned.transform.Translate(new Vector3(move, 0, 0));
                move = move - 0.9f;
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
