using UnityEngine;
using System.Collections;
using System.Net;

public class SubmitHighscore : MonoBehaviour {
    void Submit(string name, int score) {
        WebRequest request = WebRequest.Create("http://47bf6273.ngrok.com/add/" + name + "/score/" + score + "/");
        request.Method = "POST";
        request.GetResponse();
    }
}
