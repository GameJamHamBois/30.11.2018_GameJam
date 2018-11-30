using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour {

    public Rigidbody2D Body;
    public float speed;
    public int DestructionXPosition;

    private bool isHit = false;


	void Start ()
    {
        Body.velocity = new Vector2(-speed, Body.velocity.y);
    }
	
	void Update ()
    {

        if (transform.position.x <= DestructionXPosition)
        {
            GameObject.Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Body.constraints = RigidbodyConstraints2D.None;
            Body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
