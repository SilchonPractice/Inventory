using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryButtonArray : MonoBehaviour {
    private int buttonPosition;
    private const int buttonMaxSize = 12;

    public List<GameObject> inventoryButtonList = new List<GameObject>();   //인벤토리 내의 모든 버튼 리스트

    public int getButtonPosition() { return buttonPosition; }
    public int getButtonMaxSize() { return buttonMaxSize; }

    public void setButtonPosition(int buttonPosition) { this.buttonPosition = buttonPosition; }

	// Use this for initialization
	void Awake () {
        buttonPosition = 0;
        for (int i = 0; i < buttonMaxSize; i++)
        {
            inventoryButtonList.Add(null);
        }
	}
	
	// Update is called once per frame
    void Update()
    {
	}

    public void ItemButtonOnClick(Sprite itemImage)
    {
        int count = 0;
        //아이템 버튼을 누를 시 인벤토리 버튼 리스트에 추가
        while (true)
        {
            count++;
            if (inventoryButtonList[getButtonPosition()].GetComponent<InventoryButton>().button.image.sprite == null)
            {
                Debug.Log("Item Added");
                inventoryButtonList[getButtonPosition()].GetComponent<InventoryButton>().ChangeButtonImage(itemImage);
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
}