using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;

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

    private List<GameObject> hitFXPool = new List<GameObject>();
    [SerializeField] private int hitFXPoolSize = 10;
    [SerializeField] private GameObject hitFXPrefab;


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
            GameObject objBullet = Instantiate(bulletPrefab);
            objBullet.SetActive(false);
            bulletPool.Add(objBullet);
        }

        for (int i = 0; i < bulletMuzzlePoolSize; i++)
        {
            GameObject objMuzzle = Instantiate(bulletMuzzlePrefab);
            objMuzzle.SetActive(false);
            bulletMuzzlePool.Add(objMuzzle);
        }

        for (int i = 0; i < enemyPoolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }

        for (int i = 0; i < hitFXPoolSize; i++)
        {
            GameObject objHit = Instantiate(hitFXPrefab);
            objHit.SetActive(false);
            hitFXPool.Add(objHit);
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
            if (!bulletPool[i].activeInHierarchy)
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

    public GameObject GetHitFXPool()
    {
        for (int i = 0; i < hitFXPool.Count; i++)
        {
            if (!hitFXPool[i].activeInHierarchy)
            {
                return hitFXPool[i];
            }
        }

        return null;
    }




}