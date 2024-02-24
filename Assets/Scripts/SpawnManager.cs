using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 4.0f;
    public bool isGameOver = false;
    NavMeshTriangulation Triangles;

    void Start()
    {
        Triangles = NavMesh.CalculateTriangulation();
        StartCoroutine(SpawnEnemyRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
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
