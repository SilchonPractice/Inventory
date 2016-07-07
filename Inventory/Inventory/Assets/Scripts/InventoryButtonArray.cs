using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryButtonArray : MonoBehaviour {
    private int buttonPosition;

    public List<GameObject> inventoryButtonList = new List<GameObject>();   //인벤토리 내의 모든 버튼 리스트

    public int getButtonPosition() { return buttonPosition; }

    public void setButtonPosition(int buttonPosition) { this.buttonPosition = buttonPosition; }

	// Use this for initialization
	void Start () {
        buttonPosition = 0;
	}
	
	// Update is called once per frame
    void Update()
    {
	}

    public void ItemButtonOnClick(Sprite itemImage)
    {
        if (getButtonPosition() < inventoryButtonList.Count)
        {
            print("change image?");
            inventoryButtonList[getButtonPosition()].GetComponent<InventoryButton>().ChangeButtonImage(itemImage);
            setButtonPosition(getButtonPosition() + 1);
        }
    }
}