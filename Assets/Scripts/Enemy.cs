using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    
    public float moveSpeed = 3f;
    [SerializeField] float health, maxHealth = 3f;
    //[SerializeField] private Healthbar healthBar;

    private GameObject player;
    private Transform target;

    private void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");

        //healthBar.UpdateHealthBar(maxHealth, health);

    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log($"Enemy Health: {health}");

        //healthBar.UpdateHealthBar(maxHealth, health);


        if (health <= 0)
        {
            KillCount.killCount++;
            ObjectPooler.instance.GetEnemyPool();
            gameObject.SetActive(false);
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
