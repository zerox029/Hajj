using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCreation : MonoBehaviour {

    private Transform dynamic;
    public GameObject player;

    public Color[] playerColors;

    void CreatePlayerTokens(int playerCount)
    {
        for(int i = 0; i < playerCount; i++)
        {
            GameObject inst = Instantiate(player, dynamic);
            inst.GetComponent<Player>().turnNumber = i + 1;
            inst.GetComponent<SpriteRenderer>().sortingOrder = i * -1;
            inst.GetComponent<SpriteRenderer>().color = playerColors[i];
        }
    }

    void Start ()
    {
        dynamic = GameObject.FindGameObjectWithTag("Dynamic").transform;
        CreatePlayerTokens(PlayerPrefs.GetInt("PlayerCount"));
	}
}
