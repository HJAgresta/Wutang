using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrcontroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("vr")==0)
        {
            Destroy(gameObject);
        }
	}
	
}
