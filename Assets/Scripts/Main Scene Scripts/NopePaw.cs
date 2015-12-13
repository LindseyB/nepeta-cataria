using UnityEngine;
using System.Collections;

public class NopePaw : MonoBehaviour {
	void Update () {
	    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            gameObject.GetComponent<Animator>().SetTrigger("nopeTrigger");
        }
	}
}
