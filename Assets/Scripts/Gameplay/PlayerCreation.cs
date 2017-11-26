using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreation : MonoBehaviour {

    private Transform dynamic;
    public GameObject player;

    void CreatePlayerTokens(int playerCount)
    {
        for(int i = 0; i < playerCount; i++)
        {
            GameObject inst = Instantiate(player, dynamic);
            inst.GetComponent<Player>().turnNumber = i + 1;
        }
    }

    void Start ()
    {
        dynamic = GameObject.FindGameObjectWithTag("Dynamic").transform;
        CreatePlayerTokens(PlayerPrefs.GetInt("PlayerCount"));
	}
}
