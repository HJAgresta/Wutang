using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : followObject
{

    public override void activate()
    {
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Door>()!= null)
        {
            other.gameObject.GetComponent<Door>().activate();
            GameObject.Find("Player").GetComponent<Inventory>().emptyInventory();
            Destroy(gameObject);
        }
    }
}
