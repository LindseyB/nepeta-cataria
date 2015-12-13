using UnityEngine;
using System.Collections;
using System.Net;
using SimpleJSON;
using UnityEngine.UI;

public class GetHighscores : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var json = new WebClient().DownloadString("http://6b1fa8b1.ngrok.com/highscores.json");
        var result = JSON.Parse(json);
        string highscores = "";

        for(int i=0; i<10; i++) {
            highscores += string.Format("{0,-2:00}. {1,5} {2,10:0000000000}\n", (i+1), result[i]["name"].Value.ToUpper(), int.Parse(result[i]["score"].Value));
        }

        gameObject.GetComponent<Text>().text = highscores;
    }
}
