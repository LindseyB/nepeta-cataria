using UnityEngine;
using System.Collections;

public class MoveMeters : MonoBehaviour {
    float height;

    void Start() {
        StartCoroutine("Move");
    }

	void Update() {
        // TODO: do stuff based on score
	}

    IEnumerator Move() {
        while (true) {
            height = Random.Range(0.1f, 4.0f);
            foreach (LineRenderer lr in gameObject.GetComponentsInChildren<LineRenderer>()) {
                lr.SetPosition(0, new Vector3(0, height, 0));
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
