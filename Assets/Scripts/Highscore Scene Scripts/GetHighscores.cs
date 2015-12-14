using UnityEngine;
using System.Collections;
using System.Net;
using SimpleJSON;
using UnityEngine.UI;

public class GetHighscores : MonoBehaviour {

	// Use this for initialization
	void Start () {

        try {
            string json = new WebClient().DownloadString("http://nepeta-cataria-server.herokuapp.com/highscores.json");
            JSONArray result = JSON.Parse(json) as JSONArray;
            string highscores = "";

            int n = 1;
            foreach (JSONNode item in result) {
                highscores += string.Format("{0,-2:00}. {1,5} {2,10:0000000000}\n", n, item["name"].Value.ToUpper(), int.Parse(item["score"].Value));
                n++;
            }

            gameObject.GetComponent<Text>().text = highscores;
        } catch {
            // FUCK
        }
    }
}
