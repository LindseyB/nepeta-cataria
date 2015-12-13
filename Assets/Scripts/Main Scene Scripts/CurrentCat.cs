using UnityEngine;
using System.Collections;

public class CurrentCat : MonoBehaviour {
    Animator animator;
    int doneHash = Animator.StringToHash("Done");
    int moveLineHash = Animator.StringToHash("moveIntoLine");
    int moveClubHash = Animator.StringToHash("moveIntoClub");

	void Start () {
        Concatenate();
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

    // Generate a new cat with special properties
    void Concatenate () {
        Color color = new Color(Random.Range(0.0f, 1.0f),
                                Random.Range(0.0f, 1.0f),
                                Random.Range(0.0f, 1.0f));
        gameObject.transform.Find("CatTail").GetComponent<SpriteRenderer>().color = color;
        gameObject.transform.Find("CatBase").GetComponent<SpriteRenderer>().color = color;
    }
}
