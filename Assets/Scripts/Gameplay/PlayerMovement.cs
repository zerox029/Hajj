using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private TurnManager turnManager;
    private GameManager manager;

    public int currentTile; //The tile number the player is currently on
    public bool canPlay = true; //If the player is currently moving => false

    private void Start()
    {
        currentTile = 0;

        turnManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<TurnManager>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        transform.position = manager.tiles[currentTile].transform.position;
    }

    /// <summary>
    /// A coroutine that lerps the player from tile 1 to tile 2.
    /// It then check what tile the player has landed on and calls
    /// the appropriate function.
    /// </summary>
    public IEnumerator MovePlayer(int tileNumber, Transform source, Transform target, float overtime)
    {
        if(currentTile < 29 && !manager.gameEnd)
        {
            if (canPlay)
            {
                canPlay = false;

                currentTile = tileNumber;

                if(currentTile == 29)
                {
                    GetComponent<Player>().hasReachedEnd = true;
                    manager.gameEnd = manager.checkForGameEnd();
                }

                float startTime = Time.time;

                while (Time.time < startTime + overtime)
                {
                    transform.position = Vector3.Lerp(source.position, target.position, (Time.time - startTime) / overtime);
                    yield return null;
                }

                transform.position = target.position;

                turnManager.changeTurn();
                canPlay = true;
            }
        }    
    }
}
