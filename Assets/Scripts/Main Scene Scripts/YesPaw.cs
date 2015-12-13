using UnityEngine;
using System.Collections;

public class YesPaw : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			gameObject.GetComponent<Animator>().SetTrigger("yesTrigger");
		}
	}
}
