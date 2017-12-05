using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Question : MonoBehaviour {

    string jsonPath;
    string jsonString;

    public Color wrongColor;
    public Color rightColor;

    private PlayerMovement playerMove;

    Text questionTitle;
    GameObject optionA;
    GameObject optionB;
    GameObject optionC;
    GameObject optionD;

    private void Start()
    {
        jsonPath = Application.streamingAssetsPath + "/questions.json";
        jsonString = File.ReadAllText(jsonPath);
        QuestionInfo test = JsonUtility.FromJson<QuestionInfo>(jsonString);

        questionTitle = transform.Find("Question").GetComponent<Text>();
        questionTitle.text = test.question;

        optionA = transform.Find("AnswerA").gameObject;
        optionB = transform.Find("AnswerB").gameObject;
        optionC = transform.Find("AnswerC").gameObject;
        optionD = transform.Find("AnswerD").gameObject;

        optionA.GetComponentInChildren<Text>().text = test.options[0];
        optionB.GetComponentInChildren<Text>().text = test.options[1];
        optionC.GetComponentInChildren<Text>().text = test.options[2];
        optionD.GetComponentInChildren<Text>().text = test.options[3];

        for(int i = 0; i<test.difficulty.Length; i++)
        {
            if(i == test.answer)
            {
                //Add correct answer behavior
            }
            else
            {
                //Add wrong answer behavior
            }
        }
    }

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

public class QuestionInfo
{
    public string question;
    public string difficulty;
    public string[] options;
    public int answer;
}
