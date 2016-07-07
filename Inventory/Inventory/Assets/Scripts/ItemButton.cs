using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemButton : MonoBehaviour {
    private GameObject inventoryButtonPanel;

    public Sprite itemImage;

	// Use this for initialization
	void Start () {
        inventoryButtonPanel = GameObject.FindGameObjectWithTag("InventoryButtonPanel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonOnClick()
    {
        inventoryButtonPanel.GetComponent<InventoryButtonArray>().ItemButtonOnClick(itemImage);
    }
}