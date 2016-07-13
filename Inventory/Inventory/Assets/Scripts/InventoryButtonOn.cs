using UnityEngine;
using System.Collections;

public class InventoryButtonOn : MonoBehaviour {
    private bool openCheck;
    private GameObject inventoryButtonPanel;

	// Use this for initialization
	void Start () {
        openCheck = true;
        inventoryButtonPanel = GameObject.FindGameObjectWithTag("InventoryButtonPanel");
	}

    public void InventoryButtonPanelOnClick()
    {
        if (!openCheck)
        {
            //인벤토리 켜짐
            Debug.Log("Inventory On");
            inventoryButtonPanel.SetActive(true);
            openCheck = true;
        }
        else if (openCheck)
        {
            //인벤토리 꺼짐
            Debug.Log("Inventory Off");
            inventoryButtonPanel.SetActive(false);
            openCheck = false;
        }
    }
}