﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Inventory : MonoBehaviour {

    [System.NonSerialized]public Camera camera1;
    [System.NonSerialized]public bool carry;
    [System.NonSerialized]public GameObject carryObject;
    [SerializeField]public GUIStyle style;
    [SerializeField]public GUIStyle otherstyle;
    public SteamVR_Controller left;
    public SteamVR_Controller right;
    private bool controllerAClicked;
    public bool triggerClicked;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("vr") == 1)
        {
            Destroy(gameObject);
        }

        controllerAClicked = false;

        camera1 = GameObject.Find("Camera").GetComponent<Camera>();
    }

    void OnGUI()
    {
        Ray ray = camera1.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            GUI.Box(new Rect((Screen.width / 2)-5, (Screen.height / 2)-5, 10, 10), "", style);

            if (hit.collider.gameObject.GetComponent<PuzzleObject>() != null && hit.collider.gameObject.GetComponent<PuzzleObject>().interactable == true && Vector3.Distance(hit.collider.gameObject.transform.position,this.transform.position)<20)
            {
                GUI.Box(new Rect((Screen.width / 2)-5, (Screen.height / 2)-5, 10, 10), "", otherstyle);
            }
        }

    }

    public void emptyInventory()
    {
        if(carry)
        {
            carry = false;
            carryObject.transform.parent = null;
            carryObject.GetComponent<Collider>().enabled = true;
            carryObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

	void Update()
	{
        //prevents multiple calls from controller button
        if (Input.GetAxis("ControllerA") == 0)
        {
            controllerAClicked = false;
        }

        //desktop inventory
        if (Input.GetMouseButtonDown(0) || (Input.GetAxis("ControllerA") != 0 && !controllerAClicked))
        {
            controllerAClicked = true;

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
                        if (hit.collider.gameObject.GetComponent<followObject>() != null && Vector3.Distance(hit.collider.gameObject.transform.position, this.transform.position) < 20)
                        {
                            carryObject = hit.collider.gameObject;
                            carryObject.transform.parent = this.gameObject.transform;
                            carryObject.transform.localPosition = new Vector3(0.184f,0.677f,0.6f);
                            carryObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                            carry = true;
                            carryObject.GetComponent<Rigidbody>().useGravity = false;
                            carryObject.GetComponent<Collider>().enabled = false;
                            carryObject.GetComponent<Collider>().isTrigger = false;
                        }
                        else if(hit.collider.gameObject.GetComponent<PuzzleObject>() != null && Vector3.Distance(hit.collider.gameObject.transform.position, this.transform.position) < 20)
                        {
                            PuzzleObject puzzleObject =  hit.collider.gameObject.GetComponent<PuzzleObject>();
                            if (puzzleObject.interactable)
                            {
                                puzzleObject.activate();
                            }
                        }
                    }
                }
            }
            else
            {
                Ray ray = camera1.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                Debug.DrawRay(ray.origin, ray.direction * 20, Color.yellow);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.GetComponent<PuzzleObject>() != null)
                        {
                            hit.collider.gameObject.GetComponent<PuzzleObject>().activate();
                            return;
                        }
                    }
                }

                emptyInventory();
            }
        }
	}
}
