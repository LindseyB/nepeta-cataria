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
                    currentCat.GetComponentInChildren<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f),
                                                                                          Random.Range(0.0f, 1.0f),
                                                                                          Random.Range(0.0f, 1.0f));
                }
            }
        }
	}
}
