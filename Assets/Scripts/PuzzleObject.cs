using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleObject : MonoBehaviour
{
    public bool interactable = true;
    public virtual void activate(){}
}