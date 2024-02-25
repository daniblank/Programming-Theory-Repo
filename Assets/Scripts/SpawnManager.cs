using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private static SpawnManager instance;
    public static SpawnManager Instance
    {
        get
        {
            return instance;
        }
    }

    //[SerializeField] private float spawnRate = 4.0f;
    public float SpawnRate { 
        get { return spawnRate[GameManager.Instance.Difficulty]; }  
    }
    private const float spawnRateEasy = 4.0f;
    private const float spawnRateMedium = 2.0f;
    private const float spawnRateHard = 1.0f;

    Dictionary<GameManager.DifficultyType, float> spawnRate = new Dictionary<GameManager.DifficultyType, float>
    {
        {GameManager.DifficultyType.Easy, spawnRateEasy},
        {GameManager.DifficultyType.Medium, spawnRateMedium},
        {GameManager.DifficultyType.Hard, spawnRateHard}
    };


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
        while (!GameManager.Instance.IsGameOver)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(SpawnRate);
        }
    }
    private void SpawnEnemy()
    {
        Debug.Log("Spawning enemy");
        int randomIndex = Random.Range(0, Triangles.vertices.Length);
        NavMeshHit hit;
        NavMesh.SamplePosition(Triangles.vertices[randomIndex], out hit, 1.0f, NavMesh.AllAreas);
        //Instantiate(enemyPrefab, hit.position, enemyPrefab.transform.rotation);
        GameObject enemy = ObjectPool.SharedInstance.GetPooledObject();
        if (enemy != null)
        {
            enemy.transform.position = hit.position;
            enemy.transform.rotation = enemyPrefab.transform.rotation;
            enemy.SetActive(true);
        }
    }
}
