using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    Text numberTxt;

    [SerializeField]
    PlayerMovement playerMove;
    [SerializeField]
    GameManager manager;

    private void Start()
    {
        numberTxt = GameObject.FindGameObjectWithTag("DiceNumber").GetComponent<Text>();
    }

    public void RollDice()
    {
        int random = Random.Range(1, 7);
        int destTile = playerMove.currentTile + random;

        numberTxt.text = random.ToString();
        StartCoroutine(playerMove.MovePlayer(destTile, playerMove.transform, manager.tiles[destTile].transform, 1.0f));
    }
}