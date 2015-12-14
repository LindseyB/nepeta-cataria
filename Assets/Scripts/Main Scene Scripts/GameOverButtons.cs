using UnityEngine;

public class GameOverButtons : MonoBehaviour {
    void PlayAgain() {
        Application.LoadLevel("main");
    }

    void MainMenu() {
        Application.LoadLevel("start");
    }
}
