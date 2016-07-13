using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InventoryButtonArray : MonoBehaviour {
    private int buttonPosition;
    private const int buttonMaxSize = 12;
    private GameObject player;

    public List<GameObject> inventoryButtonList = new List<GameObject>();   //인벤토리 내의 모든 버튼 리스트
    public List<Sprite> itemSpriteList = new List<Sprite>();

    public int getButtonPosition() { return buttonPosition; }
    public int getButtonMaxSize() { return buttonMaxSize; }
    public void setButtonPosition(int buttonPosition) { this.buttonPosition = buttonPosition; }

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");

        //버튼의 전체 개수만큼 리스트 생성
        for (int i = 0; i < buttonMaxSize; i++)
        {
            inventoryButtonList.Add(null);
        }
        buttonPosition = 0;

        Invoke("LoadInventoryData", 0.1f);
	}
	
	// Update is called once per frame
    void Update()
    {
	}

    public void ItemButtonOnClick(Sprite itemImage, String itemName)
    {
        int count = 0;
        //아이템 버튼을 누를 시 인벤토리 버튼 리스트에 추가
        while (true)
        {
            count++;
            if (inventoryButtonList[getButtonPosition()].GetComponent<InventoryButton>().button.image.sprite == null)
            {
                Debug.Log(buttonPosition + " Button Item Added");
                inventoryButtonList[getButtonPosition()].GetComponent<InventoryButton>().ChangeButtonInfo(itemImage, itemName);
                break;
            }

            setButtonPosition(getButtonPosition() + 1);
            if (getButtonPosition() == getButtonMaxSize())
            {
                setButtonPosition(0);
            }

            if (count == getButtonMaxSize())
                break;
        }
    }

    public void SettingButtonPosition()
    {
        for (int i = 0; i < inventoryButtonList.Count; i++)
        {
            if (inventoryButtonList[i].GetComponent<InventoryButton>().button.image.sprite == null)
            {
                buttonPosition = 0;
            }
        }
    }

    public void LoadInventoryData()
    {
        //if (dataController.getDataList() != null)
        if (player.GetComponent<DataController>().getDataList() != null)
        {
            Debug.Log("Load data");

            for (int i = 0; i < player.GetComponent<DataController>().getDataList().saveInventoryButtonList.Count; i++)
            {
                if (String.Equals(player.GetComponent<DataController>().getDataList().saveInventoryButtonList[i], "Gun"))
                    inventoryButtonList[i].GetComponent<InventoryButton>().ChangeButtonInfo(itemSpriteList[0], player.GetComponent<DataController>().getDataList().saveInventoryButtonList[i]);
                else if (String.Equals(player.GetComponent<DataController>().getDataList().saveInventoryButtonList[i], "Knife"))
                    inventoryButtonList[i].GetComponent<InventoryButton>().ChangeButtonInfo(itemSpriteList[1], player.GetComponent<DataController>().getDataList().saveInventoryButtonList[i]);
                else if (String.Equals(player.GetComponent<DataController>().getDataList().saveInventoryButtonList[i], "Shield"))
                    inventoryButtonList[i].GetComponent<InventoryButton>().ChangeButtonInfo(itemSpriteList[2], player.GetComponent<DataController>().getDataList().saveInventoryButtonList[i]);
                else if (String.Equals(player.GetComponent<DataController>().getDataList().saveInventoryButtonList[i], "Shoes"))
                    inventoryButtonList[i].GetComponent<InventoryButton>().ChangeButtonInfo(itemSpriteList[3], player.GetComponent<DataController>().getDataList().saveInventoryButtonList[i]);
            }

            buttonPosition = player.GetComponent<DataController>().getDataList().saveButtonPosition;
        }
    }

    void OnApplicationQuit()
    {
        Debug.Log("Save data");
        List<string> itemNameList = new List<string>();
        for (int i = 0; i < inventoryButtonList.Count; i++)
        {
            itemNameList.Add(inventoryButtonList[i].GetComponent<InventoryButton>().getItemName());
        }
        player.GetComponent<DataController>().getDataList().saveInventoryButtonList = itemNameList;
        player.GetComponent<DataController>().getDataList().saveButtonPosition = buttonPosition;
        player.GetComponent<DataController>().SaveDatas();
    }
}