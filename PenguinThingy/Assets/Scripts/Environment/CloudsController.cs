using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsController : MonoBehaviour {

    public GameObject[] Clouds;
    public float Spawnrate;

    public Transform SpawnPoint;

    private float currentTime = 0f;
    private float spawnrate;
    private void Start()
    {
        spawnrate = Spawnrate;
    }

    void Update ()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= Spawnrate)
        {
            GameObject cloud = GameObject.Instantiate(Clouds[Random.Range(0, Clouds.Length)],SpawnPoint);
            cloud.transform.position = new Vector3(cloud.transform.position.x, Random.Range(cloud.transform.position.y, cloud.transform.position.y + 3));
            currentTime = 0;
            Spawnrate = Random.Range(Mathf.Max(0.5f,spawnrate - 1), Mathf.Max(1,spawnrate + 1));
        }
	}
}
