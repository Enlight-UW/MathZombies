using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {


    public int maxZombies = 20;
    public GameObject zombie;
    public int spawnTime = 10;

    // starting position of the first zombie
    public Vector3 pos;


    // Use this for initialization
    void Start()
    {

        pos = new Vector3(0, 0, 20);
        
        // make this depend on if the zombie has hit the player OR if a player has killed the right zombie
        InvokeRepeating("Spawn", 0, spawnTime);
    }

    void Spawn()
    {

        for (int i = 0; i < 5; i++)
        {
            Instantiate(zombie, pos, Quaternion.Euler(0, 0, 0));
            pos = rotate(pos);
        }

    }

    Vector3 rotate(Vector3 v)
    {
        return Quaternion.Euler(0, 72, 0) * v;
    }

    


}
