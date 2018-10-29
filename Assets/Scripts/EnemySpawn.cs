using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour, ISpawner 
{

    [Header("Rangos")]

    public float y;

    [Space(10)]
    public float x1;
    public float z1;

    [Space(5)]
    public float x2;
    public float z2;

    [Space(5)]
    public float x3;
    public float z3;

    [Space(5)]
    public float x4;
    public float z4;

    [Header("GameObjects")]
    [Space(10)]
    public GameObject enemigos;

    bool canSpawn = true;

    void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;
            SpawnObject();
        }
    }

    public void SpawnObject()
    {

        int random = Random.Range(1, 5);

        switch (random)
        {
            case 1:
                Vector3 position01 = new Vector3(Random.Range(x1, x4), y, Random.Range(z1, z2));
                Instantiate(enemigos, position01, Quaternion.identity);
                break;
            case 2:
                Vector3 position02 = new Vector3(Random.Range(x1, x4), y, Random.Range(z3, z4));
                Instantiate(enemigos, position02, Quaternion.identity);
                break;
            case 3:
                Vector3 position03 = new Vector3(Random.Range(x1, x2), y, Random.Range(z1, z4));
                Instantiate(enemigos, position03, Quaternion.identity);
                break;
            case 4:
                Vector3 position04 = new Vector3(Random.Range(x3, x4), y, Random.Range(z1, z4));
                Instantiate(enemigos, position04, Quaternion.identity);
                break;
        }
        StartCoroutine(WaitForRespawn());
    }
    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(5);
        canSpawn = true;
    }
}
