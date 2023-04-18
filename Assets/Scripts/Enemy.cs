using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    
    public float moveSpeed = 3f;
    [SerializeField] float health, maxHealth = 3f;

    private GameObject player;

    private Transform target;

    private void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log($"Enemy Health: {health}");

        if (health <= 0)
        {
            //destroyEnemy.Invoke();
            //Popup.enemyCount += 10;
            ObjectPool.instance.GetEnemyPool();
            gameObject.SetActive(false);
            //Destroy(gameObject);
            Debug.Log("Enemy has died.");
        }
    }

    private void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;

            Debug.Log(target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
        }
    }
}
