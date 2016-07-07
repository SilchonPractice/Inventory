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
        for (int i = 0; i < inventoryPanel.GetComponent<InventoryButtonArray>().inventoryButtonList.Count; i++)
        {
            inventoryPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().ChangeButtonImage(new Sprite());
            inventoryPanel.GetComponent<InventoryButtonArray>().setButtonPosition(0);
        }
    }
}
