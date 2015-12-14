using UnityEngine;
using System.Collections;

public class MoveMeters : MonoBehaviour {
    float height;

    void Start() {
        StartCoroutine("Move");
    }

	void Update() {
        // TODO: do stuff based on score
        foreach (LineRenderer lr in gameObject.GetComponentsInChildren<LineRenderer>()) {
            lr.SetPosition(0, new Vector3(0, Mathf.PingPong(Time.time, height), 0));
        }
    }

    IEnumerator Move() {
        while (true) {
            height = Random.Range(0.1f, 4.0f);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
