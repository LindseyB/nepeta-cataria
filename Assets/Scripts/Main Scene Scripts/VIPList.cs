﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VIPList : MonoBehaviour {

    [SerializeField] GameObject badChoice;

    private int numberOfRules     = 5;
    private int numberOfAntiRules = 3;
    private MoveMeters moveMeters;
    private Scoring scoring;

    List<Sprite> headThumbnails;
    List<Sprite> tailThumbnails;
    List<Sprite> neckThumbnails;
    List<Sprite> rules;
    List<Sprite> antiRules;

	void Start () {
        moveMeters = FindObjectOfType<MoveMeters>();
        scoring = FindObjectOfType<Scoring>();

        headThumbnails = new List<Sprite>(Resources.LoadAll<Sprite>("VIPList/Heads"));
        tailThumbnails = new List<Sprite>(Resources.LoadAll<Sprite>("VIPList/Tails"));
        neckThumbnails = new List<Sprite>(Resources.LoadAll<Sprite>("VIPList/Necks"));

        rules     = SetVIPRules(numberOfRules,     2);
        antiRules = SetVIPRules(numberOfAntiRules, 1);

        for (int i=0; i < numberOfRules; i++) {
            Transform rule   = gameObject.transform.Find("Rule" + i);
            Sprite    sprite = rule.GetComponent<SpriteRenderer>().sprite = rules[i];
            ScaleRuleSprite(sprite, rule);
        }

        for (int i = 0; i < numberOfAntiRules; i++) {
            Transform rule = gameObject.transform.Find("AntiRule" + i);
            Sprite sprite = rule.GetComponent<SpriteRenderer>().sprite = antiRules[i];
            ScaleRuleSprite(sprite, rule);
        }
    }

    private List<Sprite> SetVIPRules(int rulesYo, int maxPerCategory) {
		List<Sprite> newRules = new List<Sprite>();
		List<List<Sprite>> allRules = new List<List<Sprite>>();

		allRules.Add(headThumbnails);
		allRules.Add(tailThumbnails);
		allRules.Add(neckThumbnails);

        for (int i=0; i < rulesYo; i++) {
            Sprite rule = PickRandomRule(allRules, maxPerCategory);
            newRules.Add(rule);
        }

        return newRules;
    }

    private Sprite PickRandomRule(List<List<Sprite>> allRules, int maxPerCategory) {
        int ruleSetIndex = Random.Range(0, allRules.Count);
        List<Sprite> ruleSet = allRules[ruleSetIndex];

        int ruleIndex = Random.Range(0, ruleSet.Count);
        Sprite rule = ruleSet[ruleIndex];

		// remove the chosen rule from all possible candidates
        ruleSet.RemoveAt(ruleIndex);
		if (rule.name.Contains ("head")) {
			headThumbnails = ruleSet;
		} else if (rule.name.Contains("tail")) {
			tailThumbnails = ruleSet;
		} else if (rule.name.Contains("neck")) {
			neckThumbnails = ruleSet;
		}

		if (ruleSet.Count <= (5 - maxPerCategory)) { // 5 is the initial length of each ruleSet aka the variety of attributes per category
			allRules.RemoveAt(ruleSetIndex);
		}

        return rule;
    }

    private void ScaleRuleSprite(Sprite sprite, Transform rule) {
        if (sprite.name.Contains("tail")) {
            rule.localScale = new Vector3(0.27f, 0.27f, 0.27f);
        }
        else if (sprite.name.Contains("head")) {
            rule.localScale = new Vector3(0.29f, 0.29f, 0.29f);
        }
        else if (sprite.name.Contains("neck")) {
            rule.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
    }

    public void ScoreCat(GameObject cat) {
        int matching = 0;
        int violations = 0;
        
        foreach(Sprite sprite in rules) {
            if (sprite.name.Contains("head") &&
                sprite.name.Contains(cat.transform.Find("CatHead").GetComponent<SpriteRenderer>().sprite.name)) {
                matching++;
            } else if (sprite.name.Contains("tail") &&
                       sprite.name.Contains(cat.transform.Find("CatTail").GetComponent<SpriteRenderer>().sprite.name)) {
                matching++;
            } else if (sprite.name.Contains("neck") &&
                       sprite.name.Contains(cat.transform.Find("CatNeck").GetComponent<SpriteRenderer>().sprite.name)) {
                matching++;
            }
        }

        foreach(Sprite sprite in antiRules) {
            if (sprite.name.Contains("head") &&
                sprite.name.Contains(cat.transform.Find("CatHead").GetComponent<SpriteRenderer>().sprite.name)) {
                violations++;
            } else if (sprite.name.Contains("tail") &&
                       sprite.name.Contains(cat.transform.Find("CatTail").GetComponent<SpriteRenderer>().sprite.name)) {
                violations++;
            } else if (sprite.name.Contains("neck") &&
                       sprite.name.Contains(cat.transform.Find("CatNeck").GetComponent<SpriteRenderer>().sprite.name)) {
                violations++;
            }
        }

        int value = 0;
        if(violations > 0) {
            value = (-5 - (5 * violations));
        } else if (matching > 0) {
            value = (5 * matching);
        } else {
            value = -5;
        }

        moveMeters.UpdateMeter(value);

        if (value > 0) {
            scoring.score += (moveMeters.scoreMultiplier.currentMultiplier * value);
            scoring.UpdateScore();
        } else if (value < 0) {
            StartCoroutine(YellAtPlayer());
        }
    }

    IEnumerator YellAtPlayer() {
        badChoice.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        badChoice.SetActive(false);
    }
}
