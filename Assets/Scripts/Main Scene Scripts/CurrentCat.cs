using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurrentCat : MonoBehaviour {
    Animator animator;
    int doneHash = Animator.StringToHash("Done");
    int moveLineHash = Animator.StringToHash("moveIntoLine");
    int moveClubHash = Animator.StringToHash("moveIntoClub");

    Sprite[] tails;

	void Start () {
        tails = Resources.LoadAll<Sprite>("Tails");
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
        SpriteRenderer catTail = gameObject.transform.Find("CatTail").GetComponent<SpriteRenderer>();
        catTail.sprite = tails[Random.Range(0, tails.Length-1)];
        catTail.color = color;
        gameObject.transform.Find("CatBase").GetComponent<SpriteRenderer>().color = color;
    }
}
