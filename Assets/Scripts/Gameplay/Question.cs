using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour {

    public Color wrongColor;
    public Color rightColor;

    private PlayerMovement playerMove;

    public void wrongAnswer()
    {
        GetComponent<Image>().color = wrongColor;
    }

    public void rightAnswer()
    {
        playerMove = GameObject.FindGameObjectWithTag("Manager").GetComponent<Dice>().playerMove;

        GetComponent<Image>().color = rightColor;
        Destroy(GameObject.FindGameObjectWithTag("QPanel"));
        Destroy(GameObject.FindGameObjectWithTag("Blur"));

        playerMove.changeTurn();
    }
}
