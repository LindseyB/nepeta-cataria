using UnityEngine;
using System.Collections;

public class NopePaw : MonoBehaviour {
    MoveMeters moveMeters;

    void Start () {
        moveMeters = FindObjectOfType<MoveMeters>();
    }

	void Update () {
        if (isGameOver()) { return;  }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && NotAnimating()) {
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

    public bool isGameOver() {
        return moveMeters.gameOver;
    }

    public bool NotAnimating() {
        return ((gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash == 
                Animator.StringToHash("nopeIdle")) &&
                (GameObject.Find("YesPaw").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash == 
                Animator.StringToHash("yesPawIdle")) 
               );
    }
}
