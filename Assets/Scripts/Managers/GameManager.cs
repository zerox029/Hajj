﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] tiles;

    public bool gameEnd = false;
    public TurnManager turnManager;

    public bool checkForGameEnd()
    {
        foreach (GameObject player in turnManager.players)
        {
            if (!player.GetComponent<Player>().hasReachedEnd)
                return false;
        }
        return true;
    }

}
