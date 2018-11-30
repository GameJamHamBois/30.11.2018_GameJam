using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour {

    public Rigidbody2D Body;
    public Vector2 Force;
    /// <summary>
    /// X Coordinate an der die Vögel sich selbst zerstören.
    /// </summary>
    public int DestructionXPosition;

    private bool isHit = false;


	void Start () {
		
	}
	
	void Update ()
    {
        isHit = Input.GetKeyDown(KeyCode.E);

        if (!isHit)
        {
            Body.AddForce(Force,ForceMode2D.Force);
        }
        else
        {
            Body.constraints = RigidbodyConstraints2D.None;
        }

        if(transform.position.x <= DestructionXPosition)
        {
            GameObject.Destroy(this.gameObject);
        }
	}
}
