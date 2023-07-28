using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float spawnDelay = 2.0f;
    [SerializeField]
    private GameObject prefabToSpawn;
    [SerializeField]
    private GameObject tribleSpawn;
    [SerializeField]
    private GameObject _Conteiner;
    private bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTribleRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            int spawnx = Random.Range(-9, 9);
            GameObject Senemy = Instantiate(prefabToSpawn, new Vector3(spawnx, 8, 0), Quaternion.identity);
            Senemy.transform.parent = _Conteiner.transform;
            yield return new WaitForSeconds(spawnDelay);
        }
    } 
    IEnumerator SpawnTribleRoutine()
    {
        while (_stopSpawning == false)
        {
            int spawnx = Random.Range(-9, 9);
            GameObject tribleBuff = Instantiate(tribleSpawn, new Vector3(spawnx, 8, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 7));
        }
    }
    public void OnPlayerDead()
    {
        _stopSpawning = true;
    }
}
