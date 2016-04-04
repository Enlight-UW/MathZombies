using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour {
    public static int LENGTH_AWAY_FROM_CAMERA = 20;
    public GameObject zombie;
    public UpdateNumberHandler updateNumHandler;

    // random number generator
    Random rnd;

    // starting position of the first zombie
    public Vector3 pos;


    // Use this for initialization
    void Start()
    {
        // zombies will spawn due to update number handler doing it once it gets the new numbers
        pos = new Vector3(0, 0, LENGTH_AWAY_FROM_CAMERA);

        updateNumHandler = GameObject.Find("/UpdateNumberHandler").GetComponent<UpdateNumberHandler>();
        rnd = new Random();

        // make this depend on if the zombie has hit the player OR if a player has killed the right zombie
        //InvokeRepeating("Spawn", 0, spawnTime);
    }

    int[] reshuffle(int number)
    {
        int[] arr = new int[number];

        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < arr.Length; t++)
        {
            int tmp = arr[t];
            int r = Random.Range(t, arr.Length);
            arr[t] = arr[r];
            arr[r] = tmp;
        }

        return arr;
    }

    public void Spawn(int numberOfZombies)
    {
        int[] zombiePositions = reshuffle(numberOfZombies);

        for (int i = 0; i < numberOfZombies; i++)
        {
            int possibleSolution = 0;

            if(zombiePositions[i] == numberOfZombies - 1)
            {
                possibleSolution = updateNumHandler.sum;
            }
            else
            {
                possibleSolution = updateNumHandler.randomNum[zombiePositions[i]];
            }

            Vector3 tmpPos = pos;

            // need to vary z slightly so it doesn't call zombies twice
            tmpPos.z = tmpPos.z + 0.1f * (float) i;
            GameObject tmpZombie = (GameObject) Instantiate(zombie, tmpPos, Quaternion.Euler(0, 0, 0));

            tmpZombie.transform.Find("Body/Text").GetComponent<TextMesh>().text = "" + possibleSolution;
            pos = rotate(pos, numberOfZombies);
        }

    }

    Vector3 rotate(Vector3 v, int number)
    {
        float rotateBy = 360.0f / (float) number;
        return Quaternion.Euler(0, rotateBy, 0) * v;
    }
}
