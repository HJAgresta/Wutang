using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : PuzzleObject {

    public string combo;
    private string entered;
    public PuzzleObject act;

    public string Entered
    {
        get { return entered; }
    }

    //add number to currently typed combo
    public void addNum(string s)
    {
        if(s == "enter")
        {
            enter();
        }
        else if(s == "clear")
        {
            clear();
        }
        else
        {
            entered += s;
        }
    }

    //check combo
    void enter()
    {
        if(combo == entered)
        {
            act.activate();
        }
        else
        {
            clear();
        }
    }

    //clear combo
    void clear()
    {
        entered = "";
    }
}
