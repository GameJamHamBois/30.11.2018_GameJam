using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour {


    public GameObject SunPrefab;
    public Transform Pivot;
    public Vector2 StartPosition;
    public float TotalAngle;
    public float TravelTime;

    private float anglePerSec;

    private GameObject sun;
    private float currentTime = 0;

	void Start ()
    {
        sun = GameObject.Instantiate(SunPrefab, new Vector3(StartPosition.x, StartPosition.y, 0),Quaternion.identity);
        sun.transform.parent = Pivot.transform;
        anglePerSec = TotalAngle / TravelTime;
	}
	
	void Update ()
    {
        currentTime += Time.deltaTime;
        if(currentTime < TravelTime)
            Pivot.Rotate(0f, 0f, (anglePerSec * Time.deltaTime));

	}
}
