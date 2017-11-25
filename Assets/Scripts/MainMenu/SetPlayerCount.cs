using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerCount : MonoBehaviour {

    public int playerCount;
    private Slider slider;
    private Text playerCountText;

    private void Start()
    {
        PlayerPrefs.SetInt("PlayerCount", 1);
        slider = GameObject.FindGameObjectWithTag("PlayerSlider").GetComponent<Slider>();
        playerCountText = GameObject.FindGameObjectWithTag("PlayerCountText").GetComponent<Text>();
    }

    public void PlayerCount()
    {
        playerCount = (int)slider.value;
        playerCountText.text = playerCount.ToString();
        PlayerPrefs.SetInt("PlayerCount", playerCount);
    }
}
