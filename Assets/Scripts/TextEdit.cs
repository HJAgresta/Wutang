using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEdit : MonoBehaviour {

    public Keypad kp;
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<TextMesh>().text = kp.Entered;
	}
}
