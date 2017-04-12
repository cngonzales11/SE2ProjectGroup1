using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : Move {
    public Strike()
    {
        name = "Strike";
    }

    private const int baseDamage = 60;

	public override void perform(Character target)
    {
        target.takeDamage(baseDamage);

        Debug.Log("Strike Called on " + target);
    }
}
