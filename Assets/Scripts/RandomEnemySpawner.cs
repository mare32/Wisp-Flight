using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    //public enum SpawnState { SPAWNING, WAITING, COUNTING };
    // Start is called before the first frame update
    public Transform[] spawnPoints;
    public Enemy enemy;
    public Player player;
    //public Material texture;
    //private SpawnState state = SpawnState.COUNTING;
    //public Wave[] waves;
    //private int nextWave = 0;
    public float timeBetweenWaves = 200f;
    public float waveCountdown;
    //[System.Serializable]
    //public class Wave
    //    {
    //        public string name;
    //        public Transform enemy;
    //        public int count;
    //        public float rate;
    //    }


    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(state == SpawnState.WAITING)
        //{
        //Debug.Log(waveCountdown);
        //}
        if(waveCountdown == timeBetweenWaves)
        {
            //if(state != SpawnState.SPAWNING)
            //{
            SpawnEnemy();
                waveCountdown -= Time.deltaTime;
            //}
        }
        else if(waveCountdown > 0)
        {
            waveCountdown -= Time.deltaTime;
        }
        else
        {
            waveCountdown = timeBetweenWaves;
        }
    }
    void SpawnWave()
    {
        //state = SpawnState.SPAWNING;

        //for (int i = 0; i < _wave.count; i++)
        //{
            
            SpawnEnemy();
        //}
        //state = SpawnState.WAITING;
        //yield break;
    }
    void SpawnEnemy()
    {
        int randSpawn = Random.Range(0, 5);
        //Debug.Log(randSpawn);
        if (spawnPoints[randSpawn] == spawnPoints[0])
        {
            enemy.vertical = false;
            enemy.horizontal = true;
            enemy.reverse = false;
        }
        else if (spawnPoints[randSpawn] == spawnPoints[4])
        {
            enemy.vertical = false;
            enemy.horizontal = true;
            enemy.reverse = true;
        }
        else if (spawnPoints[randSpawn] == spawnPoints[1] || spawnPoints[randSpawn] == spawnPoints[2])
        {
            enemy.horizontal = false;
            enemy.vertical = true;
            enemy.reverse = true;
        }
        else if (spawnPoints[randSpawn] == spawnPoints[3])
        {
            enemy.horizontal = false;
            enemy.vertical = true;
            enemy.reverse = false;
        }
        enemy.player = player;
        //enemy.GetComponent<SpriteRenderer>().material.mainTexture = 
        Instantiate(enemy, spawnPoints[randSpawn].position, transform.rotation);
    }
}
