using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject enemy;
    public ParticleSystem hitFX;
    public Transform bulletHitPoint;

    //[HideInInspector] public float BulletDamage;
    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    private void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.CompareTag("Enemy"))
        {
            var enemyComponent = col.gameObject.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.TakeDamage(1);
            }

            Destroy();

        }

    }

    void Destroy()
    {
        //Instantiate(hitFX, transform.position, Quaternion.identity);

        GameObject newHitFX = ObjectPooler.instance.GetHitFXPool();
        newHitFX.transform.position = bulletHitPoint.position;
        newHitFX.SetActive(true);

        StartCoroutine(ReturnToPoolWithDelay(newHitFX, .5f));


    }

    IEnumerator ReturnToPoolWithDelay(GameObject instance, float delay)
    {
        yield return new WaitForSeconds(delay);
        instance.SetActive(false);
    }
}