﻿using UnityEngine;
using System.Collections;

public class PlayerButton : MonoBehaviour {
    private GameObject playerButtonController;
    //private bool checkButtonClick;

    public string playerName;

    //public void setCheckButtonClick(bool checkButtonClick) { this.checkButtonClick = checkButtonClick; }
    //public bool getCheckButtonClick() { return checkButtonClick; }

	// Use this for initialization
	void Start () {
        playerButtonController = GameObject.FindGameObjectWithTag("PlayerButtons");
        //checkButtonClick = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickPlayerButton()
    {
        Debug.Log("Click " + playerName);
        playerButtonController.GetComponent<PlayerButtonController>().LoadAndSavePlayerData(this.gameObject);
    }
}