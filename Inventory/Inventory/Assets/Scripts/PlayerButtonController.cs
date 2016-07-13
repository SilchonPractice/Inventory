using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerButtonController : MonoBehaviour
{
    private GameObject networkManager;
    private GameObject[] playerList;
    private GameObject resetButton;

	// Use this for initialization
	void Start () {
        playerList = GameObject.FindGameObjectsWithTag("PlayerButton");
        networkManager = GameObject.FindGameObjectWithTag("NetworkManager");
        resetButton = GameObject.FindGameObjectWithTag("ResetButton");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadAndSavePlayerData(GameObject clickPlayer)
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            if (playerList[i].GetComponent<PlayerButton>().getCheckButtonClick())
            {
                //데이터 세이브
                print("Data save etc");
                networkManager.GetComponent<ServerTest>().SaveServer(i);
                playerList[i].GetComponent<PlayerButton>().setCheckButtonClick(false);
            }
            else if (playerList[i] == clickPlayer)
            {
                //데이터 로드
                print("Data load " + clickPlayer);
                resetButton.GetComponent<ResetButton>().OnClickResetButton();
                networkManager.GetComponent<ServerTest>().LoadServer(i);
            }
        }
    }
}