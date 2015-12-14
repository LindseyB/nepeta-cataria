using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VIPList : MonoBehaviour {

    private int numberOfRules = 5;

    List<Sprite> headThumbnails;
    List<Sprite> tailThumbnails;
    List<Sprite> rules;

	// Use this for initialization
	void Start () {
        headThumbnails = new List<Sprite>(Resources.LoadAll<Sprite>("VIPList/Heads"));
        tailThumbnails = new List<Sprite>(Resources.LoadAll<Sprite>("VIPList/Tails"));
        rules = SetVIPRules();

        for (int i=0; i < numberOfRules; i++) {
            gameObject.transform.Find("Rule" + i).GetComponent<SpriteRenderer>().sprite = rules[i];
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private List<Sprite> SetVIPRules() {
        List<Sprite> newRules = new List<Sprite>();

        for (int i=0; i < numberOfRules; i++) {
            Sprite rule = PickRandomRule();
            newRules.Add(rule);
        }

        return newRules;
    }

    private Sprite PickRandomRule() {
        List<List<Sprite>> allRules = new List<List<Sprite>>();
        allRules.Add(headThumbnails);
        allRules.Add(tailThumbnails);

        int ruleSetIndex = Random.Range(0, allRules.Count);
        List<Sprite> ruleSet = allRules[ruleSetIndex];

        int ruleIndex = Random.Range(0, ruleSet.Count);
        Sprite rule = ruleSet[ruleIndex];
        ruleSet.RemoveAt(ruleIndex);

        return rule;
    }
}
