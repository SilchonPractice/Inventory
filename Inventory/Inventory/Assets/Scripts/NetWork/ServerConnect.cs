using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ServerConnect : MonoBehaviour
{

    private Dictionary<string, int> scores;

    private void Awake()
    {
        scores = new Dictionary<string, int>();
        //StartCoroutine(SubmitHighScore());
        StartCoroutine(RecieveData());
    }

    private IEnumerator RecieveData()
    {
        WWW webRequest = new WWW("http://redmine.silchon.com/select2.php");
        yield return webRequest;

        string webRequest_string = webRequest.text;
        webRequest_string = webRequest_string.Replace("(", "");
        webRequest_string = webRequest_string.Replace(")", "");
        webRequest_string = webRequest_string.Replace("=>", "");
        webRequest_string = webRequest_string.Replace("\n", "");
        //webRequest_string = webRequest_string.Replace("          ", "");
        webRequest_string = webRequest_string.Replace(" ", "");

        string[] stringSeparators = new string[] { "Array" };
        string[] lines = webRequest_string.Split(stringSeparators, System.StringSplitOptions.RemoveEmptyEntries);
        //string[] stringSeparators = new string[] { "\n" };
        //string[] lines = webRequest.text.Split(stringSeparators, System.StringSplitOptions.RemoveEmptyEntries);

        scores.Clear();
        for (int i = 0; i < lines.Length; i++)
        {
            //if (lines[i].StartsWith("[id]"))
            //{
                Debug.Log("ServerConnect : " + lines[i]);
            //}
            
            //string[] _parts = lines[i].Split(',');
            //string _name = _parts[0];
            //int _score = int.Parse(_parts[1]);
            //scores.Add(_name, _score);
        }
    }
    
}





/*
    private IEnumerator SubmitHighScore()
    {
        string _score = "111";
        string _name = "ejonghyuck";
        string _hash_origin = _name + "_" + _score + "_hash";
        WWW webRequest = new WWW("http://localhost/insertScore.php?name=" + _name + "&score=" + _score + "&hash=" + _hash);
        yield return webRequest;
        yield return StartCoroutine(RecieveRanking());
    }

    private IEnumerator RecieveRanking()
    {
        WWW webRequest = new WWW("http://localhost/loadRanking.php");
        yield return webRequest;

        string[] stringSeparators = new string[] { "\n" };
        string[] lines = webRequest.text.Split(stringSeparators, System.StringSplitOptions.RemoveEmptyEntries);

        scores.Clear();
        for (int i = 0; i < lines.Length; i++)
        {
            string[] _parts = lines[i].Split(',');
            string _name = _parts[0];
            int _score = int.Parse(_parts[1]);
            scores.Add(_name, _score);
        }
    }
    */