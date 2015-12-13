using UnityEngine;
using System.Collections;

public class SpeakerThump : MonoBehaviour {
    [SerializeField] float seconds;
    [SerializeField] float bigScale;

    float smallScale = 1f;
    float currentScale;
    float speed = 0.5f;

    private Vector3 startingScale;

	void Start () {
        startingScale = gameObject.transform.localScale;
        StartCoroutine("ThumpScale");
	}

    IEnumerator ThumpScale() {
        while (true) {
            currentScale = bigScale;
            gameObject.transform.localScale = startingScale * bigScale;

            yield return new WaitForSeconds(seconds);

            while (currentScale > smallScale) {
                currentScale -= (Time.deltaTime * speed);
                yield return new WaitForSeconds(0.1f);
                gameObject.transform.localScale = startingScale * currentScale;
            }
        }
    }
}
