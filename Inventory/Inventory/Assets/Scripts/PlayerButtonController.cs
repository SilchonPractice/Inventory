using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerButtonController : MonoBehaviour
{
    private GameObject networkManager;
    private GameObject resetButton;
    private const int maxPlayer = 3;

    public List<GameObject> playerList = new List<GameObject>();

	// Use this for initialization
	void Awake () {
        networkManager = GameObject.FindGameObjectWithTag("NetworkManager");
        resetButton = GameObject.FindGameObjectWithTag("ResetButton");

        for (int i = 0; i < maxPlayer; i++)
            playerList.Add(null);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadAndSavePlayerData(GameObject clickPlayer)
    {
        print(playerList.Count);
        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i].GetComponent<PlayerButton>().getCheckButtonClick())
            {
                //데이터 세이브
                Debug.Log("Data save " + playerList[i].name);
                networkManager.GetComponent<ServerTest>().SaveServer(i);
                playerList[i].GetComponent<PlayerButton>().setCheckButtonClick(false);
            }
        }
        for(int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i] == clickPlayer)
            {
                //데이터 로드
                Debug.Log("Data load " + clickPlayer);
                resetButton.GetComponent<ResetButton>().OnClickResetButton();
                networkManager.GetComponent<ServerTest>().LoadServer(i);
            }
        }
    }
}