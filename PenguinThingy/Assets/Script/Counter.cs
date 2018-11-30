using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

    public Text TimeText;

    private float timePassed = 0;

	void Update ()
    {
        timePassed += Time.deltaTime;

        TimeText.text = FormatTime(Mathf.FloorToInt(timePassed));
	}

    private string FormatTime(int time)
    {
        string extra = (time % 60) / 10 < 1 ? "0" : "";
        string temp = (time / 60) / 10 < 1 ? "0" : "";
        string penis = temp + (time/60).ToString() + ":" + extra + (time%60);
        return penis;
    }
}
