using UnityEngine;
using System.Collections;

public class HideHighscore : MonoBehaviour {
    void Hide() {
        GameObject.Find("HighScore").SetActive(false);
        GameObject.Find("GameOver").GetComponent<Canvas>().enabled = true;
    }
}
