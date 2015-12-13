using UnityEngine;
using System.Collections;

public class YesPaw : MonoBehaviour {
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
			gameObject.GetComponent<Animator>().SetTrigger("yesTrigger");
		}
	}
}
