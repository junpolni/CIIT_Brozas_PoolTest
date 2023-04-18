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
            GameObject bulletSpawn = ObjectPool.instance.GetBulletPool();
            GameObject bulletMuzzleSpawn = ObjectPool.instance.GetBulletMuzzlePool();

            if (bulletSpawn != null)
            {
                bulletSpawn.transform.position = BulletSpawnpoint.position;
                bulletSpawn.SetActive(true);
                StartCoroutine(ReturnBullet(bulletSpawn, 1f));

                bulletMuzzleSpawn.transform.position = BulletSpawnpoint.position;
                bulletMuzzleSpawn.SetActive(true);
                StartCoroutine(ReturnMuzzleFire(bulletMuzzleSpawn, 1f));
            }


            //Instantiate(SpawnFX, BulletSpawnpoint.position, BulletSpawnpoint.rotation);
            //var bullet = Instantiate(BulletPrefab, BulletSpawnpoint.position, BulletSpawnpoint.rotation);

            bulletSpawn.GetComponent<Rigidbody>().velocity = BulletSpawnpoint.forward * BulletSpeed;
        }
    }

    IEnumerator ReturnMuzzleFire(GameObject muzzle, float duration)
    {
        yield return new WaitForSeconds(duration);

        muzzle.SetActive(false);

    }

    IEnumerator ReturnBullet(GameObject bullet, float duration)
    {
        yield return new WaitForSeconds(duration);

        bullet.SetActive(false);
    }
}
