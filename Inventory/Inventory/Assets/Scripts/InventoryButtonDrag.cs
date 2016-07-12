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

        this.transform.position = Input.mousePosition;
    }

    public void OnInventoryButtonDrop()
    {
        Debug.Log("Button drop");

        checkDrop = true;

        foreach (GameObject switchButton in inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList)
        {
            if(checkDrop &&
                switchButton != this.gameObject &&
                this.transform.position.x > switchButton.GetComponent<InventoryButton>().button.transform.position.x - 40 &&
                this.transform.position.x < switchButton.GetComponent<InventoryButton>().button.transform.position.x + 40 &&
                this.transform.position.y > switchButton.GetComponent<InventoryButton>().button.transform.position.y - 40 &&
                this.transform.position.y < switchButton.GetComponent<InventoryButton>().button.transform.position.y + 40)
            {
                print(switchButton.GetComponent<InventoryButton>().buttonIndex + " switch button"); 
                Sprite changeSprite = button.image.sprite;
                string changeItemName = button.GetComponent<InventoryButton>().getItemName();

                button.GetComponent<InventoryButton>().ChangeButtonInfo(switchButton.GetComponent<InventoryButton>().button.image.sprite, switchButton.GetComponent<InventoryButton>().getItemName());

                switchButton.GetComponent<InventoryButton>().ChangeButtonInfo(changeSprite, changeItemName);

            }
        }
        this.transform.position = initPosition;
        button.GetComponent<InventoryButton>().setClickOn(true);
        button.GetComponent<InventoryButton>().onClickInventoryButton();
        inventoryButtonPanel.GetComponent<InventoryButtonArray>().SettingButtonPosition();
        checkDrop = false;
    }
}

//참고 사이트 : https://www.youtube.com/watch?v=c47QYgsJrWc