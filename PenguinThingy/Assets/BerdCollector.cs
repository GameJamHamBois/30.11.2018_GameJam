using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerdCollector : MonoBehaviour
{
    public int Berds;

	void Start () {
        DontDestroyOnLoad(this);
	}

    private void Update()
    {
        Berds = GameManager.Birds;
    }
}
