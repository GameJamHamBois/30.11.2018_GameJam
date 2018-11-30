using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlingShotController : MonoBehaviour {
    [SerializeField]
    float speed = 0.0f;
    [SerializeField]
    float speedPerFrame = 0.0f;
    [SerializeField]
    float maxSpeed = 0.0f;
    bool increasing = true;
    [SerializeField]
    Transform target;
    [SerializeField]
    GameObject projectilePF;
    GameObject projectile;

    float sliderFill = 0f;
    [SerializeField]
    Slider slider;
   

    Vector3 direction;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            
            
            // setting up Projectile + getting direction
            
           
             
             
            
            

            if (speed + speedPerFrame*Time.deltaTime >= maxSpeed)
            {
                increasing = false;
            }
            if (speed - speedPerFrame * Time.deltaTime <= 0)
            {
                increasing = true;
            }

            // calculating projectile speed
            if (increasing)
            {
                speed += speedPerFrame * Time.deltaTime;
            }
            else
            {
                speed -= speedPerFrame * Time.deltaTime;
            }

            sliderFill = Mathf.Clamp01(speed/maxSpeed   );
            Debug.Log(sliderFill);
            slider.value = sliderFill;

        }  
        if(Input.GetButtonUp("Fire1"))
        {
            direction = transform.position - target.position;
            projectile = Instantiate(projectilePF, transform.position, transform.rotation);

            direction.Normalize();
            
            
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            
            rb.velocity = new Vector2(-direction.x * speed, -direction.y * speed);
            speed = 0.0f;
        } 	
	}
}
