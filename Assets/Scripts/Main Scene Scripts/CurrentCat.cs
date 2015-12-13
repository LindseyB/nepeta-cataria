using UnityEngine;
using System.Collections;

public class CurrentCat : MonoBehaviour {
    Animator animator;
    int doneHash = Animator.StringToHash("Done");
    int moveLineHash = Animator.StringToHash("moveIntoLine");
    int moveClubHash = Animator.StringToHash("moveIntoClub");

	void Start () {
         // TODO: dynamically set up parts
        animator = gameObject.GetComponent<Animator>();
        
	}
	
	void Update () {
        CatAnimationState catAnimator = gameObject.GetComponentInChildren<CatAnimationState>();
        if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash == doneHash) {
            Destroy(gameObject);
        } else if(animator.GetCurrentAnimatorStateInfo(0).shortNameHash == moveLineHash || 
                  animator.GetCurrentAnimatorStateInfo(0).shortNameHash == moveClubHash) {
            catAnimator.Walk();
        } else {
            catAnimator.Stand();
        }
	}
}
