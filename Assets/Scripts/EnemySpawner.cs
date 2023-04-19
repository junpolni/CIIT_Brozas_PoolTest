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
            GameObject newEnemy = ObjectPooler.instance.GetEnemyPool();
            newEnemy.transform.position = new Vector3(Random.Range(1, 50), 0.862f, Random.Range(1, 31));
            newEnemy.SetActive(true);

            yield return new WaitForSeconds(interval);
        }
    }

    public void OnPlayerDeath()
    {
        stopEnemySpawn = true;
    }
}