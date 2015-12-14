using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurrentCat : MonoBehaviour {
    Animator animator;
    int doneHash = Animator.StringToHash("doneCat");
    int moveLineHash = Animator.StringToHash("moveIntoLine");
    int moveClubHash = Animator.StringToHash("moveIntoClub");

    Sprite[] tails,
             heads;

	void Start () {
        tails = Resources.LoadAll<Sprite>("Tails");
        heads = Resources.LoadAll<Sprite>("Heads");
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
        catTail.sprite = tails[Random.Range(0, tails.Length)];
        catTail.color = color;

        SpriteRenderer catHead = gameObject.transform.Find("CatHead").GetComponent<SpriteRenderer>();
        catHead.sprite = heads[Random.Range(0, heads.Length)];
        if (catHead.sprite.name == "cat-hair-1" || catHead.sprite.name == "cat-hair-3") {
            catHead.color = color;
        } else {
            catHead.color = Color.white;
        }

        gameObject.transform.Find("CatBase").GetComponent<SpriteRenderer>().color = color;
    }
}
