using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> bulletPool = new List<GameObject>();
    [Header("GUN")]
    [SerializeField] private int bulletPoolSize = 10;
    [SerializeField] private GameObject bulletPrefab;

    private List<GameObject> bulletMuzzlePool = new List<GameObject>();
    [SerializeField] private int bulletMuzzlePoolSize = 10;
    [SerializeField] private GameObject bulletMuzzlePrefab;

    private List<GameObject> enemyPool = new List<GameObject>();
    [Header("ENEMY")]
    [SerializeField] private int enemyPoolSize = 10;
    [SerializeField] private GameObject enemyPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            bulletPool.Add(obj);
        }

        for (int i = 0; i < bulletMuzzlePoolSize; i++)
        {
            GameObject enemy = Instantiate(bulletMuzzlePrefab);
            enemy.SetActive(false);
            bulletMuzzlePool.Add(enemy);
        }

        for (int i = 0; i < enemyPoolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    public GameObject GetBulletPool()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }

        return null;
    }

    public GameObject GetBulletMuzzlePool()
    {
        for (int i = 0; i < bulletMuzzlePool.Count; i++)
        {
            if (!bulletMuzzlePool[i].activeInHierarchy)
            {
                return bulletMuzzlePool[i];
            }
        }

        return null;
    }

    public GameObject GetEnemyPool()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                return enemyPool[i];
            }
        }

        return null;
    }


}