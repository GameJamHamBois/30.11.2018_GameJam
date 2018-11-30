using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 diff = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        diff.Normalize();
        float z_rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, z_rot+90);
    }
}
