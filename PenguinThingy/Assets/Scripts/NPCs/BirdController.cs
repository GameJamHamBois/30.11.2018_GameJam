using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour {

    public AudioClip[] deathSounds;
    public AudioClip[] reloadSounds;
    public Rigidbody2D Body;
    public float speed;
    public int DestructionXPosition;
    bool dead;

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
        if (collision.gameObject.CompareTag("Bullet") && !dead)
        {
            dead = true;
            GameManager.AudioSource.PlayOneShot(deathSounds[Random.Range(0, deathSounds.Length)]);
            collision.gameObject.SetActive(false);
            Body.constraints = RigidbodyConstraints2D.None;
            Body.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        else if(collision.gameObject.CompareTag("Ice Floe"))
        {
            GameManager.Birds++;
            Destroy(gameObject);
        }
    }
}
