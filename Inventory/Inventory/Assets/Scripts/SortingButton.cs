using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using System;
using System.IO;

public class SortingButton : MonoBehaviour {
    private GameObject inventoryButtonPanel;
    private GameObject resetButton;
    private List<string> itemNameList;
    public List<Sprite> itemSpriteList = new List<Sprite>();

	// Use this for initialization
	void Start () {
        inventoryButtonPanel = GameObject.FindGameObjectWithTag("InventoryButtonPanel");
        resetButton = GameObject.FindGameObjectWithTag("ResetButton");
        itemNameList = new List<string>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickSortingButton()
    {
        Debug.Log("Sorting");
        itemNameList.Clear();
        foreach (GameObject button in inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList)
        {
            if(button.GetComponent<InventoryButton>().getItemName() != null)
                itemNameList.Add(button.GetComponent<InventoryButton>().getItemName());
        }

        //버튼에 저장되어 있는 아이템의 이름들을 list로 저장하여 sorting
        itemNameList.Sort();

        //초기화
        resetButton.GetComponent<ResetButton>().OnClickResetButton();

        //sorting순서대로 다시 버튼에 맞게 이름과 이미지를 등록
        for (int i = 0; i < itemNameList.Count; i++)
        {
            if (String.Equals(itemNameList[i], "Gun"))
                inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().ChangeButtonInfo(itemSpriteList[0], itemNameList[i]);
            else if (String.Equals(itemNameList[i], "Knife"))
                inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().ChangeButtonInfo(itemSpriteList[1], itemNameList[i]);
            else if (String.Equals(itemNameList[i], "Shield"))
                inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().ChangeButtonInfo(itemSpriteList[2], itemNameList[i]);
            else if (String.Equals(itemNameList[i], "Shoes"))
                inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().ChangeButtonInfo(itemSpriteList[3], itemNameList[i]);

            inventoryButtonPanel.GetComponent<InventoryButtonArray>().setButtonPosition(i);
        }
    }
}