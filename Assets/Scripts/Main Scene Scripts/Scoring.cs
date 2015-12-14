using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour {
    int score = 0;
    Text[] scoreItems;

	void Start () {
        scoreItems = gameObject.GetComponentsInChildren<Text>();
        UpdateScore();
	}

	void Update () {
	
	}

    void UpdateScore() {
        foreach(Text item in scoreItems) {
            item.text = score.ToString();
        }
    }
}
