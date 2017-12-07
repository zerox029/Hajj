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
            
            switch(i)
            {
                case 0:
                    inst.GetComponent<Player>().color = "Rouge";
                    break;
                case 1:
                    inst.GetComponent<Player>().color = "Bleu";
                    break;
                case 2:
                    inst.GetComponent<Player>().color = "Vert";
                    break;
                case 3:
                    inst.GetComponent<Player>().color = "Mauve";
                    break;
                case 4:
                    inst.GetComponent<Player>().color = "Orange";
                    break;
                default:
                    inst.GetComponent<Player>().color = "unknown player";
                    break;
            }
        }
    }

    void Start ()
    {
        dynamic = GameObject.FindGameObjectWithTag("Dynamic").transform;
        CreatePlayerTokens(PlayerPrefs.GetInt("PlayerCount"));
	}
}
