using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetFollow : MonoBehaviour {

    [SerializeField] Transform targetTransform;
    [SerializeField] float speedRate = 1.0f;
    [SerializeField] Vector3 offsetPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		if( targetTransform)
        {
            offsetPosition = targetTransform.position - transform.position;
        }
	}
	


	// Update is called once per frame
	void Update () {
		if( targetTransform)
        {
           

            Vector3 dir = targetTransform.position - ( transform.position + offsetPosition);

            transform.position += (dir * speedRate);
        }
	}
}
