using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryButtonDrag : MonoBehaviour {
    private Vector3 initPosition;
    private GameObject inventoryButtonPanel;
    private bool checkDrop;
    private Button button;

    void Start()
    {
        initPosition = this.transform.position;
        inventoryButtonPanel = GameObject.FindGameObjectWithTag("InventoryButtonPanel");
        checkDrop = false;
        button = this.GetComponent<InventoryButton>().button;
    }

    public void OnInventoryButtonDrag()
    {
        Debug.Log("Button drag");

        this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10);
    }

    public void OnInventoryButtonDrop()
    {
        Debug.Log("Button drop");

        checkDrop = true;

        foreach (GameObject switchButton in inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList)
        {
            //다른 버튼의 영역안에 들어왔을 때
            if(checkDrop &&
                switchButton != this.gameObject &&
                this.transform.position.x > switchButton.GetComponent<InventoryButton>().button.transform.position.x - 40 &&
                this.transform.position.x < switchButton.GetComponent<InventoryButton>().button.transform.position.x + 40 &&
                this.transform.position.y > switchButton.GetComponent<InventoryButton>().button.transform.position.y - 40 &&
                this.transform.position.y < switchButton.GetComponent<InventoryButton>().button.transform.position.y + 40)
            {
                Debug.Log(switchButton.GetComponent<InventoryButton>().buttonIndex + " switch button"); 
                Sprite changeSprite = button.image.sprite;
                string changeItemName = button.GetComponent<InventoryButton>().getItemName();

                button.GetComponent<InventoryButton>().ChangeButtonInfo(switchButton.GetComponent<InventoryButton>().button.image.sprite, switchButton.GetComponent<InventoryButton>().getItemName());

                switchButton.GetComponent<InventoryButton>().ChangeButtonInfo(changeSprite, changeItemName);
            }
        }

        this.transform.position = initPosition; //버튼을 놓으면 다시 원래 위치로 되돌아 감
        button.GetComponent<InventoryButton>().setClickOn(true);    //자꾸 클릭이 되어서 클릭 off 시킴
        button.GetComponent<InventoryButton>().onClickInventoryButton();
        inventoryButtonPanel.GetComponent<InventoryButtonArray>().SettingButtonPosition();
        checkDrop = false;
    }
}