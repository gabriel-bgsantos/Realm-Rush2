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

    void PopulatePool() { // working with Object Pool, just getting all the objects needed in there / waiting deactivated
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++) {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy() {
        while(true) {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    void EnableObjectInPool() { // see if there's any element deactivated, if yes, activate it (all those objects sleeping will be activated)
        for(int i = 0; i < pool.Length; i++) {
            if(pool[i].activeInHierarchy == false) {
                pool[i].SetActive(true);
                return; 
            }
        }
    }
}
