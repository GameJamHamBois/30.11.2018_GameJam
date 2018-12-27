using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlingShotController : MonoBehaviour {
    [SerializeField]
    float speed = 0.0f;
    [SerializeField]
    float speedPerFrame = 0.0f;
    [SerializeField]
    float maxSpeed = 0.0f;
    
    public int birdAmount;
    bool increasing = true;
    [SerializeField]
    Transform target;
    [SerializeField]
    Transform birdSpawn;
    [SerializeField]
    Transform maxPosition;
    [SerializeField]
    GameObject[] projectilePF;
    GameObject projectile;
    bool shot = true;
    float sliderFill = 0f;
    [SerializeField]
    Slider slider;
    [SerializeField]
    Text endScore;
    [SerializeField]
    GameObject endScoreScreen;

    [SerializeField]
    score scorethingy;

    private TextMeshPro counter;

    private bool alreadyWon = false;
    

    Vector3 direction;

    // Use this for initialization
    void Start () {

		birdAmount = GameObject.FindGameObjectWithTag("BerdCollector").GetComponent<BerdCollector>().Berds;
        counter = GameObject.FindGameObjectWithTag("Counter").GetComponent<TextMeshPro>();

        counter.text = birdAmount.ToString();
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MenuScene");
    }
	
	// Update is called once per frame
	void Update () {
        if(birdAmount == 0 || scorethingy.eggAmount == 0)
        {
            alreadyWon = true;
            endScoreScreen.SetActive(true);
            endScore.text = scorethingy.PointsTE.text;
            StartCoroutine(Restart());
        }

        if (Input.GetButton("Fire1") && !alreadyWon)
        {
            // setting up Projectile + getting direction
            if (shot)
            {
                projectile = Instantiate(projectilePF[Random.Range(0,projectilePF.Length)],birdSpawn.position,birdSpawn.rotation,birdSpawn);

                shot = false;
            }
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
        if(Input.GetButtonUp("Fire1") && !alreadyWon)
        {
            if (birdAmount > 0)
            {
                projectile.transform.SetParent(null);
                direction = transform.position - target.position;
                

                direction.Normalize();


                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.velocity = new Vector2(-direction.x * speed, -direction.y * speed);
                speed = 0.0f;
                birdAmount--;
                shot = true;

                counter.text = birdAmount.ToString();
            }

        } 	
	}
}
