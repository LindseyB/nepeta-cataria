using UnityEngine;
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
    List<List<Sprite>> allRules;

    List<string> rulesOptions;
    List<string> antiRulesOptions;

    Hashtable rulesCategories;

    public int catCount = 0;

	void Start () {
        rulesCategories = new Hashtable();
        rulesCategories.Add("head", 0);
        rulesCategories.Add("tail", 0);
        rulesCategories.Add("neck", 0);

        moveMeters = FindObjectOfType<MoveMeters>();
        scoring = FindObjectOfType<Scoring>();

        headThumbnails = new List<Sprite>(Resources.LoadAll<Sprite>("VIPList/Heads"));
        tailThumbnails = new List<Sprite>(Resources.LoadAll<Sprite>("VIPList/Tails"));
        neckThumbnails = new List<Sprite>(Resources.LoadAll<Sprite>("VIPList/Necks"));

        allRules  = new List<List<Sprite>>();
        rules     = new List<Sprite>();
        antiRules = new List<Sprite>();

        allRules.Add(headThumbnails);
        allRules.Add(tailThumbnails);
        allRules.Add(neckThumbnails);

        string[] options = new string[] { "head", "head", "tail", "tail", "neck" , "neck" };
        rulesOptions     = new List<string>(options);
        options          = new string[] { "head", "tail", "neck" };
        antiRulesOptions = new List<string>(options);

        AddRule();
        AddRule();
        AddRule();
    }

    void Update() {
        if(catCount > 10 && rules.Count < 4) {
            AddRule();
        } else if(catCount > 20 && antiRules.Count < 1) {
            AddAntiRule();
        } else if(catCount > 30 && rules.Count < 5) {
            AddRule();
        } else if(catCount > 40 && antiRules.Count < 2) {
            AddAntiRule();
        } else if (catCount > 50 && antiRules.Count < 3) {
            AddAntiRule();
        }
    }
    
    private Sprite PickRandomRule(string ruleType) {
        string category;

        if (ruleType == "rule") {
            int categoryIndex = Random.Range(0, rulesOptions.Count);
            category = rulesOptions[categoryIndex];
            rulesOptions.RemoveAt(categoryIndex);
        } else {
            int categoryIndex = Random.Range(0, antiRulesOptions.Count);
            category = antiRulesOptions[categoryIndex];
            antiRulesOptions.RemoveAt(categoryIndex);
        }

        return PickRandomRuleFromCategory(category);
    }

    private Sprite PickRandomRuleFromCategory(string category) {
        List<Sprite> ruleSet;

        if (category == "head") {
            ruleSet = headThumbnails;
        } else if (category == "tail") {
            ruleSet = tailThumbnails;
        } else {
            ruleSet = neckThumbnails;
        }

        int ruleIndex = Random.Range(0, ruleSet.Count);
        Sprite rule = ruleSet[ruleIndex];
        ruleSet.RemoveAt(ruleIndex);

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
            catCount++;
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

    void AddRule() {
        rules.Add(PickRandomRule("rule"));
        Transform rule = gameObject.transform.Find("Rule" + (rules.Count-1));
        Sprite sprite = rule.GetComponent<SpriteRenderer>().sprite = rules[rules.Count-1];
        ScaleRuleSprite(sprite, rule);
    }

    void AddAntiRule() {
        antiRules.Add(PickRandomRule("antiRule"));
        Transform rule = gameObject.transform.Find("AntiRule" + (antiRules.Count - 1));
        Sprite sprite = rule.GetComponent<SpriteRenderer>().sprite = antiRules[antiRules.Count - 1];
        ScaleRuleSprite(sprite, rule);
    }
}
