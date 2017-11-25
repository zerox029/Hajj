using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameManager manager;
    public int currentTile;
    public bool canPlay = true;

    float speed = 4.0f;

    private void Start()
    {
        currentTile = 0;
        transform.position = manager.tiles[currentTile].transform.position;
    }

    private void WinGame()
    {

    }

    public IEnumerator MovePlayer(int tileNumber, Transform source, Transform target, float overtime)
    {
        if(currentTile < 29)
        {
            if (canPlay)
            {
                canPlay = false;

                currentTile = tileNumber;

                float startTime = Time.time;

                while (Time.time < startTime + overtime)
                {
                    transform.position = Vector3.Lerp(source.position, target.position, (Time.time - startTime) / overtime);
                    yield return null;
                }

                transform.position = target.position;

                canPlay = true;
            }
        }

        else
        {
            WinGame();
        }
       
    }
}
