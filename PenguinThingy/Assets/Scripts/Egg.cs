using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {
    Rigidbody2D rb;
    [SerializeField]
    BoxCollider2D stable;
    SpriteRenderer sp;
    [SerializeField]
    Sprite cracked;
    score sc;
    bool destroyed = false;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        stable = transform.parent.GetComponentInChildren<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();
        sc = GameObject.FindGameObjectWithTag("Score").GetComponent<score>();

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BossStage"))
        {
            if (destroyed == false)
            {
                
                Debug.Log("Hit stage");
                sp.sprite = cracked;
                // destroy after time
                sc.EggHit();
                stable.enabled = false;
                destroyed = true;

            }
        }
    }
}
