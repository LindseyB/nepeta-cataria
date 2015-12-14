using UnityEngine;
using System.Collections;

public class ScoreMultiplier : MonoBehaviour {
    uint currentMultiplier = 1;
    ParticleSystem glitter;
    ParticleSystem fog;
    GameObject lasers;
    Animator crowdAnimator;

	void Start() {
        glitter = gameObject.GetComponentInChildren<ParticleSystem>();
        fog = GameObject.Find("FogMachine").GetComponent<ParticleSystem>();
        lasers = GameObject.Find("Lasers");
        crowdAnimator = GameObject.Find("Crowd").GetComponent<Animator>();
    }

	void Update() {
	    if(currentMultiplier == 4 && !glitter.isPlaying) {
            glitter.Play();
            foreach(GameObject laser in lasers.GetComponentsInChildren<GameObject>()) {
                laser.SetActive(true);
            }
        } else if(glitter.isPlaying) {
           glitter.Stop();
            foreach (GameObject laser in lasers.GetComponentsInChildren<GameObject>()) {
                laser.SetActive(false);
            }
        }

        if(currentMultiplier>= 3 && !fog.isPlaying) {
            fog.Play();
        } else if(fog.isPlaying) {
            fog.Stop();
        }

        if(currentMultiplier >= 2) {
            crowdAnimator.SetTrigger("danceTrigger");
        } else {
            crowdAnimator.SetTrigger("noDanceTrigger");
        }
	}

    void IncreaseMultiplier() {
        currentMultiplier++;
    }

    void DecreaseMultiplier() {
        currentMultiplier--;
    }
}
