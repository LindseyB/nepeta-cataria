using UnityEngine;
using System.Collections;

public class CurrentCat : MonoBehaviour {
    Animator animator;
    int doneHash = Animator.StringToHash("Done");

	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
	void Update () {
        if(animator.GetCurrentAnimatorStateInfo(0).shortNameHash == doneHash) {
            Destroy(gameObject);
        }
	}
}
