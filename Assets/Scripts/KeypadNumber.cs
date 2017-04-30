using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadNumber : PuzzleObject {

    public Keypad kP;
    public string button;
    private bool active = true;

    public override void activate()
    {
        if (active)
        {
            kP.addNum(button);
            active = false;
        }

        pause();
    }

    IEnumerable pause()
    {
        yield return new WaitForSeconds(1f);
        active = false;
    }
}
