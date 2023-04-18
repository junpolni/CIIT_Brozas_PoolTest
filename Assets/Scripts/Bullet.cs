using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject enemy;

    //[HideInInspector] public float BulletDamage;
    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");

    }
    private void OnCollisionEnter(Collision col)
    {
        //Destroy(gameObject);

        if(col.gameObject.CompareTag("Enemy"))
        {
            var enemyComponent = col.gameObject.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.TakeDamage(1);
            }

            gameObject.SetActive(false);

        }

    }
}