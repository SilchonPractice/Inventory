using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//using LitJson;

public class ServerTest : MonoBehaviour
{
    private GameObject inventoryButtonPanel;

    private WWWHelper helper;


    //string url = "http://redmine.silchon.com/select2.php";
    string url = "http://redmine.silchon.com/inventory.php";
    string url_update = "http://redmine.silchon.com/inventory_update.php";
    string url_update_test = "http://redmine.silchon.com/inventory_update_test.php";

    // Use this for initialization
    void Awake()
    {
        inventoryButtonPanel = GameObject.FindGameObjectWithTag("InventoryButtonPanel");

        helper = WWWHelper.Instance;
        helper.OnHttpRequest += OnHttpRequest;
        helper.get(1000, url);
    }

    void OnHttpRequest(int id, WWW www)
    {
        if (www.error != null)
        {
            Debug.Log("[Error] " + www.error);
            return;
        }
        Debug.Log(www.text);

        String webrequest = www.text;
        webrequest = webrequest.Replace("[0]", "");
        webrequest = webrequest.Replace("(", "");
        webrequest = webrequest.Replace(")", "");
        webrequest = webrequest.Replace(" ", "");
        webrequest = webrequest.Replace("\n", "");
        string[] stringSeparators = new string[] { "=>" };
        //string[] lines = webrequest.Split(stringSeparators, System.StringSplitOptions.RemoveEmptyEntries);
        string[] lines = webrequest.Split(stringSeparators, System.StringSplitOptions.None);



        Debug.Log("player_id : " + lines[2].Substring(0, lines[2].IndexOf("[")));

        Debug.Log("button_position : " + lines[3].Substring(0, lines[3].IndexOf("[")));
        inventoryButtonPanel.GetComponent<InventoryButtonArray>().setButtonPosition(Convert.ToInt32(lines[3].Substring(0, lines[3].IndexOf("["))));

        String getrequestbutton = "";
        for (int i = 0; i < inventoryButtonPanel.GetComponent<InventoryButtonArray>().getButtonMaxSize(); i++)
        {
            if (i < inventoryButtonPanel.GetComponent<InventoryButtonArray>().getButtonMaxSize())
            {
                if (i == inventoryButtonPanel.GetComponent<InventoryButtonArray>().getButtonMaxSize()-1)
                {
                    getrequestbutton = lines[i + 4].Substring(0);
                    Debug.Log("button[" + i + "]item : " + getrequestbutton);
                }
                else
                {
                    getrequestbutton = lines[i + 4].Substring(0, lines[i + 4].IndexOf("["));
                    Debug.Log("button[" + i + "]item : " + getrequestbutton);
                }
            }

            if (String.Equals(getrequestbutton, "Gun"))
                inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().
                    ChangeButtonInfo(inventoryButtonPanel.GetComponent<InventoryButtonArray>().itemSpriteList[0], getrequestbutton);
            else if (String.Equals(getrequestbutton, "Knife"))
                inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().
                    ChangeButtonInfo(inventoryButtonPanel.GetComponent<InventoryButtonArray>().itemSpriteList[1], getrequestbutton);
            else if (String.Equals(getrequestbutton, "Shield"))
                inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().
                    ChangeButtonInfo(inventoryButtonPanel.GetComponent<InventoryButtonArray>().itemSpriteList[2], getrequestbutton);
            else if (String.Equals(getrequestbutton, "Shoes"))
                inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().
                    ChangeButtonInfo(inventoryButtonPanel.GetComponent<InventoryButtonArray>().itemSpriteList[3], getrequestbutton);
        }
    }

    public void SaveServer()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("player_id", "1");
        dic.Add("button_position", "" + inventoryButtonPanel.GetComponent<InventoryButtonArray>().getButtonPosition());
        for (int i = 0; i < 12; i++)
        {
            if (inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().getItemName()==null)
            {
                dic.Add("button" + i, "" );
            }
            else
            {
                dic.Add("button" + i, inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().getItemName());
            }
        }
        helper.post(1000, url_update, dic);
        Debug.Log("Quit");
    }
}