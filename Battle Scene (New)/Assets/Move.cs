using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move {
    protected string name;

    public abstract void perform(Character character);
}
