using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake() {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        while(true) {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    void PopulatePool() {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++) {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool() { // see if there's any element deactivated, if yes, activate it
        for(int i = 0; i < pool.Length; i++) {
            if(pool[i].activeInHierarchy == false) {
                pool[i].SetActive(true);
                return; 
            }
        }
    }
}