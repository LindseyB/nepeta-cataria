using UnityEngine;
using System.Collections;

public class YesPaw : MonoBehaviour {
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
            GameObject currentCat;
            if (currentCat = GameObject.FindWithTag("CurrentCat")) {
                gameObject.GetComponent<Animator>().SetTrigger("yesTrigger");
                currentCat.GetComponent<Animator>().SetTrigger("moveIntoClubTrigger");
                currentCat.tag = "Untagged";

                if (GameObject.FindWithTag("CurrentCat") == null) {
                    currentCat = Instantiate(currentCat);
                    currentCat.tag = "CurrentCat";
                }
            }
        }
	}
}
