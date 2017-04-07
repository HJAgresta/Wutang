using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class followObject : PuzzleObject
{

    Transform target; //the enemy's target
    float moveSpeed = 9; //move speed
    float rotationSpeed = 9; //speed of turning
    public bool follow = false;


    Transform myTransform; //current transform data of this enemy


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //target the player

    }
    public void Awake()
    {
        myTransform = transform; //cache transform data for easy access/preformance
    }
    public void Follow()
    {
        if (follow)
        {
            //rotate to look at the player
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

            //move towards the player
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
