using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Move {
    private const int hpRegained = 25;

    public Heal()
    {
        name = "Heal";
    }

    public override void perform(Character target)
    {
        target.addHealth(hpRegained);
    }
}
