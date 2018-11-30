using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class OrcaController : MonoBehaviour {

    public Rigidbody2D Body;
    public Vector2 Force;

    private bool alreadyLauched = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag + " " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("LaunchPad") && !alreadyLauched)
        {
            alreadyLauched = true;
            Body.AddForce(Force,ForceMode2D.Impulse);
        }
        else if(collision.gameObject.CompareTag("LaunchPad") && alreadyLauched)
        {
            GameObject.Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Yoink");
            GameObject.Destroy(gameObject);
        }
    }
}
