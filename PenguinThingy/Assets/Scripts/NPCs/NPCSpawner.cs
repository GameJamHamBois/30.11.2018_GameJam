using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCSpawner : MonoBehaviour {

    public Transform BirdSpawnPoint;
    public GameObject BirdPrefab;
    public float BirdSpawnrateInSec;
    public float maxBirdPosOffset;
    private float timeCounterBird;

    public Transform OrcaSpawnPoint;
    public GameObject OrcaPrefab;
    public float OrcaSpawnrateInSec;
    public float maxOrcaPosOffset;
    private float timeCounterOrca;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update ()
    {
        timeCounterBird += Time.deltaTime;
        timeCounterOrca += Time.deltaTime;

        if (OrcaSpawnPoint == null) return;
        if(timeCounterOrca >= OrcaSpawnrateInSec)
        {
            timeCounterOrca = 0;
            GameObject orca = GameObject.Instantiate(OrcaPrefab, OrcaSpawnPoint);
            orca.transform.Translate(new Vector3(Random.Range(-maxOrcaPosOffset, maxOrcaPosOffset), 0f, 0f));
        }


        if(timeCounterBird >= BirdSpawnrateInSec)
        {
            timeCounterBird = 0;

            GameObject berd = GameObject.Instantiate(BirdPrefab, BirdSpawnPoint);
            berd.transform.Translate(new Vector3(0f, Random.Range(-maxBirdPosOffset, maxBirdPosOffset), 0f));
        }
	}
}
