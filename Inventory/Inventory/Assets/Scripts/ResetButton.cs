using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetButton : MonoBehaviour {
    private GameObject inventoryPanel;

	// Use this for initialization
	void Start () {
        inventoryPanel = GameObject.FindGameObjectWithTag("InventoryButtonPanel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickResetButton()
    {
        Debug.Log("Reset");
        for (int i = 0; i < inventoryPanel.GetComponent<InventoryButtonArray>().inventoryButtonList.Count; i++)
        {
            //버튼이 클릭되어 있을 시 다시 복구시킴
            if (inventoryPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().getClickOn())
            {
                inventoryPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().onClickInventoryButton();
            }
            //이미지를 초기화
            inventoryPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().ChangeButtonInfo(new Sprite(), null);
            inventoryPanel.GetComponent<InventoryButtonArray>().setButtonPosition(0);
        }
    }
}