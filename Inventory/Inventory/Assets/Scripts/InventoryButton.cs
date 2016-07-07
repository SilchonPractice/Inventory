using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryButton : MonoBehaviour {
    private GameObject inventoryButtonPanel;

    public Button button;
    public int buttonPosition;

	// Use this for initialization
	void Start () {
        inventoryButtonPanel = GameObject.FindGameObjectWithTag("InventoryButtonPanel");

        //버튼이 생성될 때 버튼 리스트에 추가
        //inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList.Add(this.gameObject);
        inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList.Insert(buttonPosition, this.gameObject);
        inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList.RemoveAt(buttonPosition + 1);
	}
	
	// Update is called once per frame
    void Update()
    {

	}

    public void ChangeButtonImage(Sprite itemImage)
    {
        button.image.sprite = itemImage;
    }
}