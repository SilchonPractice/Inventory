using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryButton : MonoBehaviour {
    private GameObject inventoryButtonPanel;
    private bool clickOn;
    private Vector3 buttonSize;

    public Button button;
    public int buttonPosition;

    public bool getClickOn() { return clickOn; }

	// Use this for initialization
	void Start () {
        inventoryButtonPanel = GameObject.FindGameObjectWithTag("InventoryButtonPanel");
        clickOn = false;
        buttonSize = Vector3.one;

        //버튼이 생성될 때 버튼 리스트에 추가
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

    public void onClickInventoryButton()
    {
        if (clickOn)
        {
            Debug.Log("Inventory Button Click Down");
            //클릭되어있는 상태일 때
            clickOn = false;
            button.transform.localScale = buttonSize;
        }
        else
        {
            Debug.Log("Inventory Button Click On");
            //처음 클릭되었을 때
            clickOn = true;
            button.transform.localScale = buttonSize * 1.1f;
        }
    }
}