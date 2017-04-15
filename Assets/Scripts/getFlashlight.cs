using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFlashlight : MonoBehaviour {

    public GameObject Player;
    private AudioSource aud;
    private bool poss = false;

    private void Start()
    {
        aud = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        
        if (!poss && Vector3.Distance(Player.transform.position, this.transform.position) < 15)
        {
            if (Input.GetKeyDown("e"))
            {
                this.transform.position = Player.transform.position;
                this.transform.rotation = Player.transform.rotation;
                this.transform.SetParent(Player.transform);
                this.transform.Rotate(0, 180, 0);
                this.transform.Translate(-2, -1, 0);
                aud.Play();
                poss = true;
            }
        }
	}
}
