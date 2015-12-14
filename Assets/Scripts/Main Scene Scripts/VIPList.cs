using UnityEngine;
using System.Collections;

public class VIPList : MonoBehaviour {

    private int numberOfRules = 5;

    Sprite[] headThumbnails;
    Sprite[] tailThumbnails;
    Sprite[] rules;

	// Use this for initialization
	void Start () {
        headThumbnails = Resources.LoadAll<Sprite>("VIPList/Heads");
        tailThumbnails = Resources.LoadAll<Sprite>("VIPList/Tails");
        rules = SetVIPRules();

        gameObject.transform.Find("Rule1").GetComponent<SpriteRenderer>().sprite = rules[0];
        gameObject.transform.Find("Rule2").GetComponent<SpriteRenderer>().sprite = rules[1];
        gameObject.transform.Find("Rule3").GetComponent<SpriteRenderer>().sprite = rules[2];
        gameObject.transform.Find("Rule4").GetComponent<SpriteRenderer>().sprite = rules[3];
        gameObject.transform.Find("Rule5").GetComponent<SpriteRenderer>().sprite = rules[4];
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private Sprite[] SetVIPRules() {
        Sprite[] newRules = new Sprite[numberOfRules];

        for (int i=0; i < numberOfRules; i++) {
            Sprite rule = PickRandomRule();
            newRules[i] = rule;
        }

        return newRules;
    }

    private Sprite PickRandomRule() {
        Sprite[][] allRules = new Sprite[2][];
        allRules[0] = headThumbnails;
        allRules[1] = tailThumbnails;

        Sprite[] ruleSet = allRules[Random.Range(0, allRules.Length)];
        Sprite rule = ruleSet[Random.Range(0, ruleSet.Length)];

        Debug.Log(rule.name);
        return rule;
    }
}
