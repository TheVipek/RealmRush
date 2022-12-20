using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyRam;
    [SerializeField] [Range(0,50)]int poolSize;
    [SerializeField] [Range(0.1f,30f)]float spawnSpeed;
    GameObject[] pool;

    private void Awake() {
        populatePool();
    }
    void Start()
    {
        StartCoroutine(spawningRams());
    }
    void populatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyRam,transform);
            //pool[i].SetActive(false);
        }
    }
    void enableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if(!pool[i].activeSelf)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator spawningRams(){

        while(true)
        {
            enableObjectInPool();
            yield return new WaitForSeconds(spawnSpeed);
        }
        
    }
}
