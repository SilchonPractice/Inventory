using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataController : MonoBehaviour {
    [Serializable]  //데이터 저장을 위해 필요
    public class SaveData
    {
        //데이터를 저장하는 클래스
        public int saveButtonPosition;
        public List<String> saveInventoryButtonList;
    }

    private SaveData dataList = new SaveData();

    public SaveData getDataList() { return dataList; }

	// Use this for initialization
	void Awake () {
        var data = PlayerPrefs.GetString("Data");

        if (!string.IsNullOrEmpty(data))
        {
            var binaryFormatter = new BinaryFormatter();
            var memoryStream = new MemoryStream(Convert.FromBase64String(data));

            dataList = (SaveData)binaryFormatter.Deserialize(memoryStream);
        }
	}

    public void SaveDatas()
    {
        var binaryFormatter = new BinaryFormatter();
        var memoryStream = new MemoryStream();

        binaryFormatter.Serialize(memoryStream, dataList);
        PlayerPrefs.SetString("Data", Convert.ToBase64String(memoryStream.GetBuffer()));    //"Data" : 일종의 저장 아이디
    }
}