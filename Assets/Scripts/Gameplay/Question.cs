using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Question : MonoBehaviour {

    string jsonPath;
    string jsonString;

    public Color wrongColor;
    public Color rightColor;

    PlayerMovement playerMove;
    QuestionInfo test;

    Text diffText;
    Text rewardText;
    Text questionTitle;
    GameObject[] options;

    private void Start()
    {
        jsonPath = Application.streamingAssetsPath + "/questions.json";
        jsonString = File.ReadAllText(jsonPath);
        test = JsonUtility.FromJson<QuestionInfo>(jsonString);

        questionTitle = transform.Find("Question").GetComponent<Text>();
        questionTitle.text = test.question;

        options = new GameObject[] { transform.Find("AnswerA").gameObject,
                                     transform.Find("AnswerB").gameObject,
                                     transform.Find("AnswerC").gameObject,
                                     transform.Find("AnswerD").gameObject };

        options[0].GetComponentInChildren<Text>().text = test.options[0];
        options[1].GetComponentInChildren<Text>().text = test.options[1];
        options[2].GetComponentInChildren<Text>().text = test.options[2];
        options[3].GetComponentInChildren<Text>().text = test.options[3];

        //Setting the buttons
        for(int i = 0; i<test.options.Length; i++)
        {
            if(i == test.answer - 1)
            {
                options[i].GetComponent<Button>().onClick.AddListener(rightAnswer);
            }
            else
            {
                options[i].GetComponent<Button>().onClick.AddListener(wrongAnswer);
            }
        }

        diffText = transform.Find("Difficulty").GetComponent<Text>();
        diffText.text = "Difficulty: " + test.difficulty;
        rewardText = transform.Find("Money").GetComponent<Text>();
        rewardText.text =  test.reward.ToString() + "$";

    }

    public void wrongAnswer()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = wrongColor;

        if(test.reward > 100)
        {
            test.reward -= 100;
        }

        else
        {
            test.reward = 0;
        }

        rewardText.text = test.reward.ToString() + "$";
    }

    public void rightAnswer()
    {
        playerMove = GameObject.FindGameObjectWithTag("Manager").GetComponent<Dice>().playerMove;

        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = wrongColor;
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
    public int reward;
}
