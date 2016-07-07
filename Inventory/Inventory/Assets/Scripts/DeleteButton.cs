using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeleteButton : MonoBehaviour {
    private GameObject inventoryPanel;

	// Use this for initialization
	void Start () {
        inventoryPanel = GameObject.FindGameObjectWithTag("InventoryButtonPanel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickDeleteButton()
    {
        for (int i = 0; i < inventoryPanel.GetComponent<InventoryButtonArray>().getButtonMaxSize(); i++)
        {
            if (inventoryPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().getClickOn())
            {
                Debug.Log("Delete");
                inventoryPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().ChangeButtonImage(new Sprite());
                inventoryPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().onClickInventoryButton();
                inventoryPanel.GetComponent<InventoryButtonArray>().setButtonPosition(0);
            }
        }
    }
}