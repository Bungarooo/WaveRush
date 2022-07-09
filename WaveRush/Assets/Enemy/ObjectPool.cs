using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [Range(0,50)]
    [SerializeField] int poolSize = 5;

    [Range(0.1f,20f)]
    [SerializeField] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyPrefab, this.transform);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    
}
