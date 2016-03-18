using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {


    // z goes from 0 to -18 or so
    // x goes from 0 

    public int maxZombies = 20;
    public GameObject zombie;
    public float spawnTime = 3f;
    public float x = 0f;
    public float y = 0f;
    public float z = 0f;

    public Vector3[] spawnPoints = new Vector3[5];
  

    //private Vector3 originPosition;

    // Use this for initialization
    void Start()
    {

        spawnPoints[0] = new Vector3(0, 0, -10);
        spawnPoints[1] = new Vector3(23, 4, 5);
        spawnPoints[2] = new Vector3(-18, 0, -13);
        spawnPoints[3] = new Vector3(0, 0, 16);
        spawnPoints[4] = new Vector3(10, 2, -5);

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {

        int spawnPointIndex = Random.Range(0, 4);
        Vector3 randomPosition = spawnPoints[spawnPointIndex];

        Instantiate(zombie, randomPosition, Quaternion.Euler(0, 0, 0));

    }
}
