﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("DisplayWebcam Initialize");
        // Transform values of the plane to get you started:
        // position 0   0   200
        // rotation 90  180 0
        // scale    80  1   40
        var devices = WebCamTexture.devices;
        var backCamName = "";

        if (devices.Length > 0)
        {
            backCamName = devices[0].name;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backCamName = devices[i].name;
            }
        }
        var CameraTexture = new WebCamTexture(backCamName, 10000, 10000, 30);
        CameraTexture.Play();
        var renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = CameraTexture;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}