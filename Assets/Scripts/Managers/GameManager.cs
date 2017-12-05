using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] tiles;

    public bool gameEnd = false;
    public TurnManager turnManager;

    private void Start()
    {
        PlayerPrefs.SetInt("questionId", 0);
    }

    public bool checkForGameEnd()
    {
        foreach (GameObject player in turnManager.players)
        {
            if (!player.GetComponent<Player>().hasReachedEnd)
                return false;
        }
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
