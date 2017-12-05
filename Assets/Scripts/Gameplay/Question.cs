using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LitJson;

public class Question : MonoBehaviour {

    string jsonPath;
    string jsonString;

    JsonData questionData;
    JsonData question;

    QuestionData questionDataObj;

    public Color wrongColor;
    public Color rightColor;

    PlayerMovement playerMove;

    Text diffText;
    Text rewardText;
    Text questionTitle;
    GameObject[] options;

    private void Start()
    {
        //Getting the JSON value
        jsonPath = Application.streamingAssetsPath + "/questions.json";
        jsonString = File.ReadAllText(jsonPath);
        questionData = JsonMapper.ToObject(jsonString);

        question = getQuestion(0);

        questionDataObj.name = question["question"].ToString();
        questionDataObj.options[0] = question["options"][0].ToString();
        questionDataObj.options[1] = question["options"][1].ToString();
        questionDataObj.options[2] = question["options"][2].ToString();
        questionDataObj.options[3] = question["options"][3].ToString();
        questionDataObj.answer = (int)question["answer"];
        questionDataObj.difficulty = question["difficulty"].ToString();
        questionDataObj.reward = (int)question["reward"];


        //Setting question title
        questionTitle = transform.Find("Question").GetComponent<Text>();
        questionTitle.text = questionDataObj.name;

        //Getting options
        options = new GameObject[] { transform.Find("AnswerA").gameObject,
                                     transform.Find("AnswerB").gameObject,
                                     transform.Find("AnswerC").gameObject,
                                     transform.Find("AnswerD").gameObject };

        //Setting options text
        options[0].GetComponentInChildren<Text>().text = questionDataObj.options[0];
        options[1].GetComponentInChildren<Text>().text = questionDataObj.options[1];
        options[2].GetComponentInChildren<Text>().text = questionDataObj.options[2];
        options[3].GetComponentInChildren<Text>().text = questionDataObj.options[3];

        //Setting the buttons
        for(int i = 0; i < questionDataObj.options.Length; i++)
        {
            if(i == questionDataObj.answer - 1)
            {
                options[i].GetComponent<Button>().onClick.AddListener(rightAnswer);
            }
            else
            {
                options[i].GetComponent<Button>().onClick.AddListener(wrongAnswer);
            }
        }

        diffText = transform.Find("Difficulty").GetComponent<Text>();
        diffText.text = "Difficulty: " + questionDataObj.difficulty;
        rewardText = transform.Find("Money").GetComponent<Text>();
        rewardText.text =  questionDataObj.reward + "$";
    }

    public void wrongAnswer()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = wrongColor;

        if((int)question["reward"] > 100)
        {
            questionDataObj.reward -= 100;
        }

        else
        {
            questionDataObj.reward = 0;
        }

        rewardText.text = questionDataObj.reward.ToString() + "$";
    }

    public void rightAnswer()
    {
        playerMove = GameObject.FindGameObjectWithTag("Manager").GetComponent<Dice>().playerMove;

        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = wrongColor;
        Destroy(GameObject.FindGameObjectWithTag("QPanel"));
        Destroy(GameObject.FindGameObjectWithTag("Blur"));

        playerMove.changeTurn();
    }

    JsonData getQuestion(int id)
    {
        for(int i = 0; i <questionData["questions"].Count; i++)
        {
            if ((int)questionData["questions"][i]["id"] == id)
                return questionData["questions"][i];
        }

        return null;
    }
}

public class QuestionData
{
    public string name;
    public string[] options;
    public int answer;
    public string difficulty;
    public int reward;
}
