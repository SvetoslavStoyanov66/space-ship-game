using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float spawnDelay = 5.0f;
    [SerializeField]
    private GameObject prefabToSpawn;
    [SerializeField]
    private GameObject _Conteiner;
    private bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnRoutine()
    {
        int spawnx = Random.Range(-9, 9);
        while (_stopSpawning == false)
        {

             GameObject Senemy = Instantiate(prefabToSpawn, new Vector3(spawnx, 8, 0), Quaternion.identity);
            Senemy.transform.parent = _Conteiner.transform;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    public void OnPlayerDead()
    {
        _stopSpawning = true;
    }
}
