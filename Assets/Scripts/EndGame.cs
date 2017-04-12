using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : PuzzleObject {

    public Image img;
    public float fadeSpeed;
    private bool gameOver;

	// Use this for initialization
	void Start () {
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            img.enabled = true;
            img.color = Color.Lerp(img.color, Color.black, fadeSpeed * Time.deltaTime);
            if(img.color.a > .95)
            {
                gameOver = false;
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        else
        {
            img.color = Color.Lerp(img.color, Color.clear, fadeSpeed * Time.deltaTime);
        }
    }

    public override void activate()
    {
        gameOver = true;
    }
}
