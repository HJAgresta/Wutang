using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	
	public Camera camera1;
	void Update()
	{
        Ray ray = camera1.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
        }
        if (Input.GetMouseButtonDown(0))
        {

            

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if(hit.collider.gameObject.GetComponent<followObject>() != null)
                    {
                        hit.collider.gameObject.GetComponent<followObject>().follow = true;
                    }
                }
            }
        }
	}
}
