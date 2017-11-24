using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameManager manager;
    public int currentTile;

    private float speed = 3.0f;

    private void Start()
    {
        currentTile = 0;
        transform.position = manager.tiles[currentTile].transform.position;
    }

    public IEnumerator MovePlayer(int tileNumber, Transform source, Transform target, float overtime)
    {
        float startTime = Time.time;
        while(Time.time < startTime + overtime)
        {
            transform.position = Vector3.Lerp(source.position, target.position, (Time.time - startTime) / overtime);
            yield return null;
        }

        transform.position = target.position;

        currentTile = tileNumber;
    }
}
