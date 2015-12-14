using UnityEngine;
using System.Collections;
using System.Net;
using UnityEngine.UI;

public class SubmitHighscore : MonoBehaviour {
    void Submit() {
        int score = 0; // TODO: replace with actual score
        string name = GameObject.Find("Name").GetComponent<Text>().text;

        WebRequest request = WebRequest.Create("http://nepeta-cataria-server.herokuapp.com/add/" + name + "/score/" + score + "/");
        request.Method = "POST";
        request.GetResponse();

        GameObject.Find("HighScore").SetActive(false);
        GameObject.Find("GameOver").GetComponent<Canvas>().enabled = true;
    }
}
