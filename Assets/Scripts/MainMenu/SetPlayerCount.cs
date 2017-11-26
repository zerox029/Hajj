using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerCount : MonoBehaviour {

    public int playerCount = 1;
    public Slider slider;
    public Text playerCountText;

    private void Start()
    {
        PlayerPrefs.SetInt("PlayerCount", 1);
    }

    public void PlayerCount()
    {
        playerCount = (int)slider.value;
        playerCountText.text = playerCount.ToString();
        PlayerPrefs.SetInt("PlayerCount", playerCount);
    }
}
