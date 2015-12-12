using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {
    void Update() {
        if (Input.GetKey("escape") || Input.GetKey(KeyCode.Q)) {
            Exit();
        }
    }

    void Exit() {
        Application.Quit();
    }
}
