using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject[] tiles;
    public GameObject gameEndPanel;
    public GameObject blur;
    public Canvas overUI;

    public bool gameEnd = false;
    public TurnManager turnManager;

    private void Start()
    {
        PlayerPrefs.SetInt("questionId", 0);
    }

    void getRankings()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Text rankingPanel = gameEndPanel.transform.Find("Players").GetComponent<Text>();
        rankingPanel.text = "";

        foreach(GameObject go in players)
        {
            rankingPanel.text += go.GetComponent<Player>().color + ": " + go.GetComponent<Player>().balance + "$\n";
        }
    }

    public bool checkForGameEnd()
    {
        foreach (GameObject player in turnManager.players)
        {
            if (!player.GetComponent<Player>().hasReachedEnd)
                return false;
        }

        Instantiate(blur, overUI.transform);
        Instantiate(gameEndPanel, overUI.transform);
        getRankings();
        return true;
    }

    public void quitGame()
    {
        //If we are running in a standalone build of the game
        #if UNITY_STANDALONE
            //Quit the application
            Application.Quit();
        #endif

        //If we are running in the editor
        #if UNITY_EDITOR
            //Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
