using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    public float Speed;
    public float SpeedRange;

    private float speed;

    private void Start()
    {
        speed = Random.Range(Speed - SpeedRange, Speed + SpeedRange);
    }

    void Update ()
    {
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);

        if (transform.position.x <= -7)
            GameObject.Destroy(gameObject);
	}
}
