using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadNumber : PuzzleObject {

    public Keypad kP;
    public string button;

    public override void activate()
    {
        kP.addNum(button);
    }
}
