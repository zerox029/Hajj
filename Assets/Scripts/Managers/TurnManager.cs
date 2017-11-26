using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public GameObject[] players;

    int playerCount;
    int turn = 0;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerCount = PlayerPrefs.GetInt("PlayerCount");
        changeTurn();
    }

    public void changeTurn()
    {
        if (turn < playerCount)
        {
            turn++;

            if (!players[turn - 1].GetComponent<Player>().hasReachedEnd)
                LinkDice();
            else
                changeTurn();
        }

        else
        {
            turn = 1;

            if (!players[turn - 1].GetComponent<Player>().hasReachedEnd)
                LinkDice();
            else
                changeTurn();
        }
    }

    void LinkDice()
    {
        Dice dice = GameObject.FindGameObjectWithTag("Manager").GetComponent<Dice>();

        foreach(GameObject player in players)
        {
            int playerTurn = player.GetComponent<Player>().turnNumber;

            if(playerTurn == turn)
            {
                dice.playerMove = player.GetComponent<PlayerMovement>();
            }
        }
    }

}
