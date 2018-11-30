using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloePhaseCC : MonoBehaviour
{
    [SerializeField] private GameObject gunPivot, penguin, bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float gunCD, shotForceMod, bulletDespawnTime;


    private Rigidbody2D penguinRB;
    private Camera mainCam;
    private float cooldownCounter;

    private void Start()
    {
        penguinRB = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
    }

    private void Update()
    {
        HandleGun();
    }

    private void HandleGun()
    {
        Vector3 pos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetVec = new Vector3(pos.x, pos.y, 0f) - gunPivot.transform.position;
        gunPivot.transform.right = targetVec;

        if (Input.GetMouseButtonDown(0) && cooldownCounter < 0f)
        {
            cooldownCounter = gunCD;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(targetVec.x, targetVec.y) * shotForceMod, ForceMode2D.Impulse);
            StartCoroutine(DestroyBulletWithDelay(bullet));
        }
        else cooldownCounter -= Time.deltaTime;
    }

    private IEnumerator DestroyBulletWithDelay(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletDespawnTime);
        Destroy(bullet);
    }
}
