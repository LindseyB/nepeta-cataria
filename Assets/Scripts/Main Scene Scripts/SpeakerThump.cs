using UnityEngine;
using System.Collections;

public class SpeakerThump : MonoBehaviour {
    [SerializeField] float seconds;
    [SerializeField] float bigScale;

    float smallScale = 1f;
    float currentScale;
    float speed = 0.5f;

	void Start () {
        StartCoroutine("ThumpScale");
	}

    IEnumerator ThumpScale() {
        while (true) {
            currentScale = bigScale;
            gameObject.transform.localScale = Vector3.one * bigScale;

            yield return new WaitForSeconds(seconds);

            while (currentScale > smallScale) {
                currentScale -= (Time.deltaTime * speed);
                yield return new WaitForSeconds(0.1f);
                gameObject.transform.localScale = Vector3.one * currentScale;
            }
        }
    }
}
