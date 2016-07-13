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
    }

    public void LoadServer(int id)
    {
        helper.get(id, url);
    }


    void OnHttpRequest(int id, WWW www)
    {
        if (www.error != null)
        {
            Debug.Log("[Error] " + www.error);
            return;
        }
        Debug.Log(www.text);

        String id_webrequest = www.text;

        id_webrequest = id_webrequest.Replace("Array", "");
        id_webrequest = id_webrequest.Replace("(", "");
        id_webrequest = id_webrequest.Replace(")", "");
        id_webrequest = id_webrequest.Replace(" ", "");
        id_webrequest = id_webrequest.Replace("\n", "");

        string[] id_stringSeparators = new string[] { "[player_id]" };
        string[] id_lines = id_webrequest.Split(id_stringSeparators, System.StringSplitOptions.None);

        for (int j = 1; j < id_lines.Length; j++)
        {
            Debug.Log("test : " + id_lines[j].Substring(2, id_lines[j].IndexOf("[") - 2));

            if (String.Equals("" + id, id_lines[j].Substring(2, id_lines[j].IndexOf("[") - 2)))
            {

                //LoadServer(id_lines[1]);
                //--------------------------------------------------------------------

                String webrequest = id_lines[j];
                string[] stringSeparators = new string[] { "=>" };
                string[] lines = webrequest.Split(stringSeparators, System.StringSplitOptions.None);

                inventoryButtonPanel.GetComponent<InventoryButtonArray>().setButtonPosition(Convert.ToInt32(lines[2].Substring(0, lines[2].IndexOf("["))));

                String getrequestbutton = "";
                for (int i = 0; i < inventoryButtonPanel.GetComponent<InventoryButtonArray>().getButtonMaxSize(); i++)
                {
                    if (i < inventoryButtonPanel.GetComponent<InventoryButtonArray>().getButtonMaxSize())
                    {
                        if (i == inventoryButtonPanel.GetComponent<InventoryButtonArray>().getButtonMaxSize() - 1)
                        {
                            getrequestbutton = lines[i + 3].Substring(0);
                            //Debug.Log("button[" + i + "]item : " + getrequestbutton);
                        }
                        else
                        {
                            getrequestbutton = lines[i + 3].Substring(0, lines[i + 3].IndexOf("["));
                            //Debug.Log("button[" + i + "]item : " + getrequestbutton);
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
        }

    }
    public void SaveServer(int id)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("player_id", "" + id);
        dic.Add("button_position", "" + inventoryButtonPanel.GetComponent<InventoryButtonArray>().getButtonPosition());
        for (int i = 0; i < 12; i++)
        {
            if (inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().getItemName() == null)
            {
                dic.Add("button" + i, "");
            }
            else
            {
                dic.Add("button" + i, inventoryButtonPanel.GetComponent<InventoryButtonArray>().inventoryButtonList[i].GetComponent<InventoryButton>().getItemName());
            }
        }
        helper.post(id, url_update, dic);
    }
}