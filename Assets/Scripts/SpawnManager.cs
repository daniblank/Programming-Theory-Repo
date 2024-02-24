using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 4.0f;
    private static SpawnManager instance;
    public static SpawnManager Instance
    {
        get
        {
            return instance;
        }
    }

    public bool isGameOver = false;
    NavMeshTriangulation Triangles;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        Triangles = NavMesh.CalculateTriangulation();
        StartCoroutine(SpawnEnemyRoutine());
    }


    IEnumerator SpawnEnemyRoutine()
    {
        while (!isGameOver)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }
    }
    private void SpawnEnemy()
    {
        Debug.Log("Spawning enemy");
        int randomIndex = Random.Range(0, Triangles.vertices.Length);
        NavMeshHit hit;
        NavMesh.SamplePosition(Triangles.vertices[randomIndex], out hit, 1.0f, NavMesh.AllAreas);
        Instantiate(enemyPrefab, hit.position, enemyPrefab.transform.rotation);
    }
}
