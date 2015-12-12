using UnityEngine;
using System.Collections;

public class RotateLaser : MonoBehaviour {
    [SerializeField] float maxRotation;
    [SerializeField] float minRotation;

    float rotationSpeed = 10.0f;
    float multiplier = 1;
	
	void Update () {
        Vector3 rot = gameObject.transform.rotation.eulerAngles;

        if (rot.z <= minRotation) {
            multiplier = 1;
        }

        if (rot.z >= maxRotation) {
            multiplier = -1;
        }

        rot.z = rot.z + ( multiplier * rotationSpeed * Time.deltaTime);

        gameObject.transform.eulerAngles = rot;
	}
}
