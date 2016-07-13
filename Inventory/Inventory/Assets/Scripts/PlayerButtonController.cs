using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerButtonController : MonoBehaviour
{
    private GameObject networkManager;
    private GameObject[] playerList;

	// Use this for initialization
	void Start () {
        playerList = GameObject.FindGameObjectsWithTag("PlayerButton");
        networkManager = GameObject.FindGameObjectWithTag("NetworkManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadAndSavePlayerData(GameObject clickPlayer)
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            if (playerList[i] == clickPlayer)
            {
                //데이터 로드
                print("Data load " + clickPlayer);
            }
            else
            {
                //데이터 세이브
                print("Data save etc");
            }
        }
    }
}