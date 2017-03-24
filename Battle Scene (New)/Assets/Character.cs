using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public int maxHp;
    public int hp;

    public Strike move = new Strike();
    public int attack;
    public int defense;
    public int speed;

    public static int maxMoves = 4;
    public Move[] moves = new Move[maxMoves];

    public void takeDamage(int damage)
    {
        this.hp -= (damage / defense);

        Debug.Log(this + " took " + (damage / defense) + " damage, HP is now " + this.hp + ".");

        if(isDead())
        {
            battleSystem.getInstance().endBattle();
        }
    }

    public void addHealth(int health)
    {
        if (health < 0) return;

        if (health + hp > maxHp)
        {
            hp = maxHp;
            return;
        }

        hp += health;
    }

    void Start()
    {
        moves[0] = move;
    }

    public bool isDead()
    {
        if (hp <= 0)
        {
            hp = 0;
            return true;
        }

        return false;
    }
}
