using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class battleSystem {

    public GameObject player;
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
            currentMove.perform(tar);
            currentMove = null;
            tar = null;
        }
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

    public void endBattle()
    {
        Debug.Log("Battle Over");
        SceneManager.LoadScene("FloorBattleFinish");
    }

}
