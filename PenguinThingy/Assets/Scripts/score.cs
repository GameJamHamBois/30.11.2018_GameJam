using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public int eggAmount = 10;
    int points = 0;
    public Text PointsTE;
    [SerializeField]
    SlingShotController ssc;
	// Use this for initialization
	void Start () {
        PointsTE.text = "Score: " + points;
        ssc = GameObject.FindGameObjectWithTag("SlingShot").GetComponentInChildren<SlingShotController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (ssc.birdAmount == 0|| eggAmount == 0)
        {
            points += ssc.birdAmount;
            Debug.Log(ssc.birdAmount);
        }
	}
    public void EggHit()
    {
        eggAmount--;
        points += 10;
        Debug.Log(points);
        PointsTE.text = "Score: " + points;
        
    }

}
