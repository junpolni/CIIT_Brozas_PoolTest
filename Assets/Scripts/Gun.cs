using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletSpawnpoint;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public GameObject SpawnFX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FireGun();
    }

    public void FireGun()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bulletSpawn = ObjectPooler.instance.GetBulletPool();
            GameObject bulletMuzzleSpawn = ObjectPooler.instance.GetBulletMuzzlePool();

            if (bulletSpawn != null)
            {
                bulletSpawn.transform.position = BulletSpawnpoint.position;
                bulletSpawn.SetActive(true);
                StartCoroutine(ReturnToPoolWithDelay(bulletSpawn, 1f));

                bulletMuzzleSpawn.transform.position = BulletSpawnpoint.position;
                bulletMuzzleSpawn.SetActive(true);
                StartCoroutine(ReturnToPoolWithDelay(bulletMuzzleSpawn, 1f));

            }

            //Instantiate(SpawnFX, BulletSpawnpoint.position, BulletSpawnpoint.rotation);
            //var bullet = Instantiate(BulletPrefab, BulletSpawnpoint.position, BulletSpawnpoint.rotation);

            bulletSpawn.GetComponent<Rigidbody>().velocity = BulletSpawnpoint.forward * BulletSpeed;
        }
    }

    IEnumerator ReturnToPoolWithDelay(GameObject instance, float delay)
    {
        yield return new WaitForSeconds(delay);
        instance.SetActive(false);
    }


}
