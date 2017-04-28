using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrselect : MonoBehaviour {

	public void vrOn()
    {
        PlayerPrefs.SetInt("vr", 0);
        Application.LoadLevel(45);
    }

    public void vrOff()
    {
        PlayerPrefs.SetInt("vr", 1);
        Debug.Log(PlayerPrefs.GetInt("vr"));
        Application.LoadLevel(45);
    }
}
