using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzle : MonoBehaviour {

    public GameObject player;
    public Light l1;
    public Light l2;
    public Light l3;
    public Light l4;
    public Light l5;
    public Light l6;
    public Light l7;
    public PuzzleObject act;
    private List<Light> lights;

	// Use this for initialization
	void Start () {
        l1 = l1.GetComponent<Light>();
        l2 = l2.GetComponent<Light>();
        l3 = l3.GetComponent<Light>();
        l4 = l4.GetComponent<Light>();
        l5 = l5.GetComponent<Light>();
        l6 = l6.GetComponent<Light>();
        l7 = l7.GetComponent<Light>();

        lights = new List<Light>();
        lights.Add(l1);
        lights.Add(l2);
        lights.Add(l3);
        lights.Add(l4);
        lights.Add(l5);
        lights.Add(l6);
        lights.Add(l7);
    }
	
	// Update is called once per frame
	void Update () {
        foreach(Light li in lights)
        {
            if (Input.GetKeyDown("e") && Vector3.Distance(player.transform.position, li.transform.position) < 8)
            {
                if(li.enabled)
                {
                    li.enabled = false;
                }
                else
                {
                    li.enabled = true;
                }
            }
        }

        //check for correct lights
        if(!lights[0].enabled && lights[1].enabled && !lights[2].enabled && lights[3].enabled && lights[4].enabled && !lights[5].enabled && lights[6].enabled)
        {
            act.activate();
        }
	}
}
