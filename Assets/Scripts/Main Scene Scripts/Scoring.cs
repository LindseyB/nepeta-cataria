using UnityEngine;
using UnityEngine.UI;
using System.Net;
using SimpleJSON;

public class Scoring : MonoBehaviour {
    public int score = 0;
    Text[] scoreItems;

	void Start () {
        scoreItems = gameObject.GetComponentsInChildren<Text>();
        UpdateScore();
	}

    public void UpdateScore() {
        foreach(Text item in scoreItems) {
            item.text = score.ToString();
        }
    }

    public bool isHighscore() {
        string json = new WebClient().DownloadString("http://nepeta-cataria-server.herokuapp.com/highscores.json");
        JSONArray result = JSON.Parse(json) as JSONArray;
        return score > result[result.Count - 1]["score"].AsInt;
    }
}
