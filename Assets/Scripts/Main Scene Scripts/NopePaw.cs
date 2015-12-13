using UnityEngine;
using System.Collections;

public class NopePaw : MonoBehaviour {
	void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            GameObject currentCat;
            if (currentCat = GameObject.FindWithTag("CurrentCat")) {
                gameObject.GetComponent<Animator>().SetTrigger("nopeTrigger");
                currentCat.tag = "Untagged";

                currentCat.SetActive(false); // temporary

                if (GameObject.FindWithTag("CurrentCat") == null) {
                    currentCat = Instantiate(currentCat);
                    currentCat.SetActive(true); // temporary
                    currentCat.tag = "CurrentCat";
                }
            }
        }
	}
}
