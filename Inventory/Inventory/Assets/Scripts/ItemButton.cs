﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemButton : MonoBehaviour {
    private GameObject inventoryButtonPanel;

    public Sprite itemImage;
    public string itemName;

	// Use this for initialization
	void Start () {
        inventoryButtonPanel = GameObject.FindGameObjectWithTag("InventoryButtonPanel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonOnClick()
    {
        Debug.Log("Item Button Clicked");
        inventoryButtonPanel.GetComponent<InventoryButtonArray>().ItemButtonOnClick(itemImage, itemName);
    }
}