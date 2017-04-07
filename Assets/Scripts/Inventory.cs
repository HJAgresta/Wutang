using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public Camera camera1;
    bool carry;
    GameObject carryObject;
    [SerializeField]public GUIStyle style;
    [SerializeField]public GUIStyle otherstyle;

    

    void OnGUI()
    {
        Ray ray = camera1.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            GUI.Box(new Rect((Screen.width / 2)-5, (Screen.height / 2)-5, 10, 10), "", style);

            if (hit.collider.gameObject.GetComponent<followObject>() != null && hit.collider.gameObject.GetComponent<followObject>().interactable == true)
            {
                GUI.Box(new Rect((Screen.width / 2)-5, (Screen.height / 2)-5, 10, 10), "", otherstyle);
            }
        }

    }

    public void emptyInventory()
    {

        carry = false;
        Debug.Log("drop");
        carryObject.transform.parent = null;
        carryObject.GetComponent<Rigidbody>().useGravity = true;
    }
	void Update()
	{
        if (Input.GetMouseButtonDown(0))
        {

            if(!carry)
            {
                Ray ray = camera1.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                Debug.DrawRay(ray.origin, ray.direction * 20, Color.yellow);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.GetComponent<followObject>() != null)
                        {
                            carryObject = hit.collider.gameObject;
                            carryObject.transform.parent = this.gameObject.transform;
                            carryObject.transform.localPosition = new Vector3(0.184f,0.677f,0.6f);
                            carry = true;
                            carryObject.GetComponent<Rigidbody>().useGravity = false;
                        }
                        else if(hit.collider.gameObject.GetComponent<PuzzleObject>() != null)
                        {
                            PuzzleObject puzzleObject =  hit.collider.gameObject.GetComponent<PuzzleObject>();
                            puzzleObject.activate();
                        }
                    }
                }
            }
            else
            {
                carry = false;
                Debug.Log("drop");
                carryObject.transform.parent = null;
                carryObject.GetComponent<Rigidbody>().useGravity = true;
                carryObject = null;
            }
        }
	}
}
