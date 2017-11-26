using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour {

    public GameObject pauseMenu;

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
	}

    public void closeMenu()
    {
        pauseMenu.SetActive(false);
    }
}
