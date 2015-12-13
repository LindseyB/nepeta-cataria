using UnityEngine;
using System.Collections;

public class YesPaw : MonoBehaviour {
    NopePaw nopePaw;

    void Start() {
        nopePaw = GameObject.Find("NopePaw").GetComponent<NopePaw>();
    }

	void Update () {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && nopePaw.NotAnimating()) {
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
