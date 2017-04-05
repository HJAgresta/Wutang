using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	
	public Camera camera1;
	void Update()
	{

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = camera1.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.yellow);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject.GetComponent<PuzzleObject>() != null)
                {
                    Debug.Log("hitsomething");
                    GameObject puzzleObject = hit.collider.gameObject;
                    //if (puzzleObject.GetComponent<PuzzleObject>().interactable)
                    //{
                    //    Debug.Log(puzzleObject.name);
                    //}
                }
            }
        }
	}
}
