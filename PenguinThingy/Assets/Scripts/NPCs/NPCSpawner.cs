using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour {

    public Transform BirdSpawnPoint;
    public GameObject BirdPrefab;
    public int BirdSpawnrateInSec;
    private float timeCounterBird;

    public Transform OrcaSpawnPoint;
    public GameObject OrcaPrefab;
    public int OrcaSpawnrateInSec;
    private float timeCounterOrca;
    /// <summary>
    /// bei erster Berührung wird Orca gelauncht,
    /// bei Zweiter zerstört.
    /// </summary>



	void Start ()
    {
    }

	void Update ()
    {
        timeCounterBird += Time.deltaTime;
        timeCounterOrca += Time.deltaTime;

        if(timeCounterOrca >= OrcaSpawnrateInSec)
        {
            timeCounterOrca = 0;
            GameObject Orca = GameObject.Instantiate(OrcaPrefab, OrcaSpawnPoint);
        }


        if(timeCounterBird >= BirdSpawnrateInSec)
        {
            timeCounterBird = 0;

            GameObject.Instantiate(BirdPrefab, BirdSpawnPoint);
        }

	}
}
