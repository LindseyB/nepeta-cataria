using UnityEngine;
using System.Collections;

public class MoveMeters : MonoBehaviour {
    int meter_value = 25;
    const int MAX_METER = 120;
    float height;
    public ScoreMultiplier scoreMultiplier;

    void Start() {
        scoreMultiplier = FindObjectOfType<ScoreMultiplier>();
        StartCoroutine("Drain");
    }

	void Update() {
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

    IEnumerator Drain() {
        while (true) {
            yield return new WaitForSeconds(1f);
            if (meter_value > 0) { meter_value--; }
        }
    }
}
