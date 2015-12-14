using UnityEngine;
using System.Collections;

public class ScoreMultiplier : MonoBehaviour {
    ParticleSystem glitter;
    ParticleSystem fog;
    GameObject lasers;
    Animator crowdAnimator;
    Animator multAnimator;

    public int currentMultiplier = 1;

    int[] hashes = new int[] {
        Animator.StringToHash("triggerMult1"),
        Animator.StringToHash("triggerMult2"),
        Animator.StringToHash("triggerMult3"),
        Animator.StringToHash("triggerMult4")
    };

	void Start() {
        glitter = gameObject.GetComponentInChildren<ParticleSystem>();
        fog = GameObject.Find("FogMachine").GetComponent<ParticleSystem>();
        lasers = GameObject.Find("Lasers");
        crowdAnimator = GameObject.Find("Crowd").GetComponent<Animator>();
        multAnimator = gameObject.GetComponent<Animator>();
    }

	void Update() {
	    if(currentMultiplier == 4) {
            if(!glitter.isPlaying) { glitter.Play(); }
            foreach(Transform laser in lasers.transform) {
                laser.gameObject.GetComponent<LineRenderer>().enabled = true;
            }
        } else {
            if(glitter.isPlaying) { glitter.Stop(); }
            foreach (Transform laser in lasers.transform) {
                laser.gameObject.GetComponent<LineRenderer>().enabled = false;
            }
        }

        if(currentMultiplier>= 3) {
            if(!fog.isPlaying) { fog.Play(); }
        } else if(fog.isPlaying) {
            fog.Stop();
        }

        if(currentMultiplier >= 2) {
            crowdAnimator.SetTrigger("danceTrigger");
        } else {
            crowdAnimator.SetTrigger("noDanceTrigger");
        }
	}

    public void HandleAnimations() {
        multAnimator.SetTrigger(hashes[currentMultiplier-1]);
    }
}
