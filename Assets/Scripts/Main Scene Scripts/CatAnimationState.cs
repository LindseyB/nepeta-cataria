using UnityEngine;
using System.Collections;

public class CatAnimationState : MonoBehaviour {
    Animator animator;

    void Start() {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Walk() {
        animator.SetTrigger("catMoveTrigger");
    }

    public void Stand() {
        animator.SetTrigger("catStopTrigger");
    }
}
