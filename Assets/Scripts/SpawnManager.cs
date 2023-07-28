using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float spawnDelay = 5.0f;
    [SerializeField]
    private GameObject prefabToSpawn;
    // Start is called before the first frame update
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
        while (true)
        {

            Instantiate(prefabToSpawn, new Vector3(spawnx, 8, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
