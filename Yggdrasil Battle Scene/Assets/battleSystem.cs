using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleSystem {

    public GameObject player;
    public GameObject enemy;
    private static battleSystem BattSys = new battleSystem();
    private Character tar = null;
    private Move currentMove = null;
    private Move[] moves;

	// Use this for initialization
	public void Start () {
        Character playerChar = player.GetComponent<Character>();
        moves = playerChar.moves;
	}

    private battleSystem()
    {

    }

    public bool turnReady()
    {
        if (tar != null && currentMove != null) return true;

        return false;
    }
	
	// Update is called once per frame
	public void Update () {
        if (tar)
        {
            Debug.Log(tar);
        }

        turn();
	}

    public void turn()
    {
        if(turnReady())
        {
            if (player.GetComponent<Character>().speed > tar.speed)
            {
                playerTurn();
                computerTurn();
            }

            else
            {
                computerTurn();
                playerTurn();
            }
        }
    }

    public void playerTurn()
    {
        currentMove.perform(tar);
        currentMove = null;
        tar = null;
    }

    public void computerTurn()
    {
        Move enemyMove = new Strike();
        enemyMove.perform(player.GetComponent<Character>());
    }

    public void selectMove1()
    {
        currentMove = moves[0];
    }

    public void selectMove2()
    {
        currentMove = moves[1];
    }

    public void selectMove3()
    {
        currentMove = moves[2];
    }

    public void selectMove4()
    {
        currentMove = moves[3];
    }

    public void setTarget(Character target)
    {
        tar = target;
    }

    public static battleSystem getInstance()
    {
        return BattSys;
    }

    public bool hasCurrentMove()
    {
        if (currentMove != null) return true;

        return false;
    }

    public bool hasTarget()
    {
        if (tar != null) return true;

        return false;
    }

    public void setCurrentPlayer(GameObject newPlayer)
    {
        player = newPlayer;
    }

    public void setCurrentEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }

    public void endBattle()
    {
        Debug.Log("Battle Over");
        Application.Quit();
    }

}
