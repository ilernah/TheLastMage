using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform targetTransform;
    public float followSpeed = 0.1f;
    Camera camera;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        camera.orthographicSize = (Screen.height / 100f);
        //if target exists
        if (targetTransform) {
            //Transform targetTransform = target.GetComponent<Transform>();

            //adding new vector to move camera by Z
            transform.position = Vector3.Lerp(transform.position, targetTransform.position, followSpeed) + new Vector3(0, 0, -1);
        }
    }
}
