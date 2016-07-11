using UnityEngine;
using System.Collections;

public class InventoryButtonOn : MonoBehaviour {
    private bool openCheck;
    private GameObject inventoryButtonPanel;

    public GameObject panel;

	// Use this for initialization
	void Start () {
        openCheck = true;
        inventoryButtonPanel = GameObject.FindGameObjectWithTag("InventoryButtonPanel");
	}
	
	// Update is called once per frame
    //void Update () {
    //    OnClick();
    //}

    //void OnClick()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        GameObject target = GetClickedObject();
    //        if (target != null && target.Equals(gameObject))
    //        {
    //            if (!openCheck)
    //            {
    //                Debug.Log("Inventory On");
    //                inventoryButtonPanel.SetActive(true);
    //                openCheck = true;
    //            }
    //            else if (openCheck)
    //            {
    //                Debug.Log("Inventory Off");
    //                inventoryButtonPanel.SetActive(false);
    //                openCheck = false;
    //            }
    //        }
    //    }
    //}

    public void InventoryButtonPanelOnClick()
    {
        if (!openCheck)
        {
            Debug.Log("Inventory On");
            inventoryButtonPanel.SetActive(true);
            openCheck = true;
        }
        else if (openCheck)
        {
            Debug.Log("Inventory Off");
            inventoryButtonPanel.SetActive(false);
            openCheck = false;
        }
    }
}