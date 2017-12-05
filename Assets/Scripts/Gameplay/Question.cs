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

    public string title;
    public string[] options;
    public int answer;
    public string difficulty;
    public int reward;

    public Color wrongColor;
    public Color rightColor;

    PlayerMovement playerMove;

    Text diffText;
    Text rewardText;
    Text questionTitle;
    GameObject[] optionsBtn;

    private void Start()
    {
        //Getting the JSON value
        jsonPath = Application.streamingAssetsPath + "/questions.json";
        jsonString = File.ReadAllText(jsonPath);
        questionData = JsonMapper.ToObject(jsonString);

        int questionId = PlayerPrefs.GetInt("questionId", 0);
        question = getQuestion(questionId);
        options = new string[4]; 

        title = question["question"].ToString();
        options[0] = question["options"][0].ToString();
        options[1] = question["options"][1].ToString();
        options[2] = question["options"][2].ToString();
        options[3] = question["options"][3].ToString();
        answer = (int)question["answer"];
        difficulty = question["difficulty"].ToString();
        reward = (int)question["reward"];


        //Setting question title
        questionTitle = transform.Find("Question").GetComponent<Text>();
        questionTitle.text = title;

        //Getting options buttons
        optionsBtn = new GameObject[] { transform.Find("AnswerA").gameObject,
                                        transform.Find("AnswerB").gameObject,
                                        transform.Find("AnswerC").gameObject,
                                        transform.Find("AnswerD").gameObject };

        //Setting options text
        optionsBtn[0].GetComponentInChildren<Text>().text = options[0];
        optionsBtn[1].GetComponentInChildren<Text>().text = options[1];
        optionsBtn[2].GetComponentInChildren<Text>().text = options[2];
        optionsBtn[3].GetComponentInChildren<Text>().text = options[3];

        //Setting the buttons
        for(int i = 0; i < options.Length; i++)
        {
            if(i == answer - 1)
            {
                optionsBtn[i].GetComponent<Button>().onClick.AddListener(rightAnswer);
            }
            else
            {
                optionsBtn[i].GetComponent<Button>().onClick.AddListener(wrongAnswer);
            }
        }

        diffText = transform.Find("Difficulty").GetComponent<Text>();
        diffText.text = "Difficulty: " + difficulty;
        rewardText = transform.Find("Money").GetComponent<Text>();
        rewardText.text =  reward + "$";
    }

    public void wrongAnswer()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = wrongColor;

        if((int)question["reward"] > 100)
        {
            reward -= 100;
        }

        else
        {
            reward = 0;
        }

        rewardText.text = reward.ToString() + "$";
    }

    public void rightAnswer()
    {
        PlayerPrefs.SetInt("questionId", PlayerPrefs.GetInt("questionId", 0) + 1);
        playerMove = GameObject.FindGameObjectWithTag("Manager").GetComponent<Dice>().playerMove;

        playerMove.gameObject.GetComponent<Player>().balance += reward;

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
