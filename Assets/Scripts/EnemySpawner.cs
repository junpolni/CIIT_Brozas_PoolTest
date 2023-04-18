using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject swarmerPrefab;

    [SerializeField] private float swarmerInterval = 3.5f;

    [SerializeField] private bool stopEnemySpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(swarmerInterval, swarmerPrefab));
    }

    IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        while (stopEnemySpawn == false)
        {
            GameObject newEnemy = ObjectPool.instance.GetEnemyPool();
            newEnemy.transform.position = new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0);
            newEnemy.SetActive(true);

            yield return new WaitForSeconds(interval);
            //StartCoroutine(SpawnEnemy(interval, enemy));
            //GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        }

        
    }
    public void OnPlayerDeath()
    {
        stopEnemySpawn = true;
    }
}