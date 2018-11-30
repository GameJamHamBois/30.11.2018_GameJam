using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloePhaseCC : MonoBehaviour
{
    public static bool canAct = true;

    [SerializeField] private GameObject gunPivot, penguin, bulletPrefab, lowerBody;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private AudioClip[] bulletSounds;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private Sprite jumpSprite;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private float gunCD;
    [SerializeField] private float reloadCD;
    [SerializeField] private float bulletDespawnTime;
    [SerializeField] private Rigidbody2D penguinRB;
    [SerializeField] private LayerMask groundLayer;


    [Header("Modifiers")]
    [SerializeField] private float shotForceMod;
    [SerializeField] private float jumpForceMod;
    [SerializeField] private float bobbingMod;
    [SerializeField] private float movespeedMod;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;


    private BoxCollider2D penguinBC;
    private Camera mainCam;
    private SpriteRenderer lowerBodySpriteRenderer;
    private float cooldownCounter;
    private float reloadCounter;
    private bool reloadNeeded = false;
    private bool grounded;

    private void Start()
    {
        penguinBC = GetComponent<BoxCollider2D>();
        mainCam = Camera.main;
        lowerBodySpriteRenderer = lowerBody.GetComponent<SpriteRenderer>();
        SetOrthSize();
        reloadCounter = reloadCD;
    }

    private void SetOrthSize()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        mainCam.orthographicSize = 1920 / currentAspect / 200;
    }

    private void Update()
    {
        if (!canAct) return;
        HandleInput();
        CheckGround();
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time) * bobbingMod, transform.position.z);
        if (grounded) lowerBodySpriteRenderer.sprite = normalSprite;
        else lowerBodySpriteRenderer.sprite = jumpSprite;
    }


    private void HandleInput()
    {
        Vector3 pos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetVec = new Vector3(pos.x, pos.y, 0f) - gunPivot.transform.position;
        gunPivot.transform.right = targetVec;

        if (Input.GetMouseButton(0) && cooldownCounter < 0f)
        {
            reloadCounter = reloadCD;
            cooldownCounter = gunCD;
            GameManager.AudioSource.PlayOneShot(bulletSounds[Random.Range(0, bulletSounds.Length)]);
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(targetVec.x, targetVec.y) * shotForceMod, ForceMode2D.Impulse);
            StartCoroutine(DestroyBulletWithDelay(bullet));
            reloadNeeded = true;
        }
        else cooldownCounter -= Time.deltaTime;
        
        if (reloadNeeded && reloadCounter < 0f)
        {
            GameManager.AudioSource.PlayOneShot(reloadSound);
            reloadCounter = reloadCD;
            reloadNeeded = false;
        }
        else if (reloadNeeded) reloadCounter -= Time.deltaTime;

        float hMovement = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(hMovement * movespeedMod, 0f, 0f));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded) Jump();
    }

    private void Jump()
    {
        GameManager.AudioSource.PlayOneShot(jumpSound);
        grounded = false;
        penguinRB.AddForce(transform.up * jumpForceMod, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(penguin.transform.position, Vector3.up * -1, 1.4f, groundLayer);
        if (hit.transform != null) grounded = true;
        else grounded = false;
    }

    private IEnumerator DestroyBulletWithDelay(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletDespawnTime);
        Destroy(bullet);
    }
}
