using UnityEngine;
using System.Collections;

public class MoveMeters : MonoBehaviour {
    int meter_value = 25;
    const int MAX_METER = 120;
    float height;

    public ScoreMultiplier scoreMultiplier;
    public bool gameOver = false;

    Scoring scoring;
    VIPList vipList;

    void Start() {
        scoreMultiplier = FindObjectOfType<ScoreMultiplier>();
        scoring = FindObjectOfType<Scoring>();
        vipList = FindObjectOfType<VIPList>();
        StartCoroutine("Drain");
    }

	void Update() {
        if (gameOver) { return; }

        if (meter_value <= 0) {
            GameOver();
        }

        height = ((meter_value / 100.0f) * 4);

        foreach (LineRenderer lr in gameObject.GetComponentsInChildren<LineRenderer>()) {
            lr.SetPosition(0, new Vector3(0, height, 0));
        }

        if(meter_value >= 100) {
            scoreMultiplier.currentMultiplier = 4;
            scoreMultiplier.HandleAnimations();
        } else if(meter_value >= 75) {
            scoreMultiplier.currentMultiplier = 3;
            scoreMultiplier.HandleAnimations();
        } else if(meter_value >= 50) {
            scoreMultiplier.currentMultiplier = 2;
            scoreMultiplier.HandleAnimations();
        } else {
            scoreMultiplier.currentMultiplier = 1;
            scoreMultiplier.HandleAnimations();
        }
    }

    public void UpdateMeter(int value) {
        meter_value += value;

        if (meter_value > MAX_METER) {
            meter_value = MAX_METER;
        } else if (meter_value < 0) {
            meter_value = 0;
        }
    }

    void GameOver() {
        gameOver = true;
        if (scoring.isHighscore()) {
            GameObject.Find("HighScore").GetComponent<Canvas>().enabled = true;
        } else {
            GameObject.Find("GameOver").GetComponent<Canvas>().enabled = true;
        }
    }

    IEnumerator Drain() {
        while (true) {
            yield return new WaitForSeconds(1f);
            if (meter_value > 0) { meter_value -= ((vipList.catCount / 20) + 1); }
        }
    }
}
