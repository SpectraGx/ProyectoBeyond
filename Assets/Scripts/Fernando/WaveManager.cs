using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int numWaves = 3; // Número de oleadas
    public float timeBetweenWaves = 10f; // Tiempo entre oleadas
    public float timeBetweenEnemies = 1f; // Tiempo entre cada enemigo en una oleada
    public GameObject[] enemyPrefabs; // Prefabs de enemigos
    public Transform[] spawnPoints; // Spawns de enemigos
    private Wave[] waves; // Oleadas de enemigos

    void Start()
    {
        waves = new Wave[numWaves];
        for (int i = 0; i < numWaves;)
        {

        }
    }
}

public class Wave
{
    public int numEnemies; // Número de enemigos en la oleada
    public float timeBetweenEnemies; // Tiempo entre cada enemigo
    public GameObject[] enemyPrefabs; // Prefabs de enemigos
    public Transform[] spawnPoints; // Spawns de enemigos
}
