using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour {
    public int score = 0;
    Text[] scoreItems;

	void Start () {
        scoreItems = gameObject.GetComponentsInChildren<Text>();
        UpdateScore();
	}

	void Update () {
	
	}

    public void UpdateScore() {
        foreach(Text item in scoreItems) {
            item.text = score.ToString();
        }
    }
}
