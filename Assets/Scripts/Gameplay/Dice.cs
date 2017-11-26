using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    Text numberTxt;

    public PlayerMovement playerMove;
    public GameManager manager;

    private void Start()
    {
        numberTxt = GameObject.FindGameObjectWithTag("DiceNumber").GetComponent<Text>();
    }

    public void RollDice()
    {
        if(playerMove.canPlay && !manager.gameEnd)
        {
            int random = Random.Range(1, 7);
            int destTile = playerMove.currentTile + random;
            numberTxt.text = random.ToString();

            if (destTile < 29)
            {
                StartCoroutine(
                    playerMove.MovePlayer(
                    destTile,
                    playerMove.transform,
                    manager.tiles[destTile].transform,
                    0.6f));
            }

            else
            {
                StartCoroutine(
                    playerMove.MovePlayer(
                    29,
                    playerMove.transform,
                    manager.tiles[29].transform,
                    0.6f));
            }
        }
    }
}