using UnityEngine;
using System.Collections;

public class NopePaw : MonoBehaviour {

    int nopeHash = Animator.StringToHash("nopeAnimation");

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.DownArrow)) {
            gameObject.GetComponent<Animator>().SetTrigger("nopeTrigger");
        }
	}
}
