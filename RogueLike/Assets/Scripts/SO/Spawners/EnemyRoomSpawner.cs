using System.Collections;
using UnityEngine;

public class EnemyRoomSpawner : MonoBehaviour
{
    public GridController grid;
    public RandomSpawner[] spawnerData;
    public GameObject Manager;
    public int itemSpawned = 0;


    public void Start()
    {
        Manager = GameObject.Find("GameManager");
        StartCoroutine(ChangeManagerTotalEnemiesCoroutine());
    }

    public void InitialiseObjectSpawning()
    {
        foreach (RandomSpawner rs in spawnerData)
        {
            SpawnObjects(rs);
        }
    }

    void SpawnObjects(RandomSpawner data)
    {
        int randomIteration = Random.Range(data.spawnerData.minSpawn, data.spawnerData.maxSpawn + 1);

        for(int i = 0; i < randomIteration; i++)
        {
            int randomPos = Random.Range(0, grid.avaliablePoints.Count - 1);
            GameObject go = Instantiate(data.spawnerData.itemToSpawn, grid.avaliablePoints[randomPos], Quaternion.identity, transform); 
            itemSpawned++;
            grid.avaliablePoints.RemoveAt(randomPos);
        }   
    }

    public IEnumerator ChangeManagerTotalEnemiesCoroutine()
    {
        yield return new WaitForSeconds(1);
        Manager.GetComponent<KillManager>().TotalEnemies += itemSpawned;
    }
}
