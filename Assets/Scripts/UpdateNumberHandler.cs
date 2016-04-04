﻿using UnityEngine;
using System.Collections;
using SimpleJSON;

public class UpdateNumberHandler : MonoBehaviour {
	public int term1;
	public int term2;
	public int sum;
	public int[] randomNum;
    ZombieSpawner spawner;

    public static int NUM_RAND_ZOMBIES = 4;

	// Use this for initialization
	void Start () {
        spawner = GameObject.Find("/ZombieSpawner").GetComponent<ZombieSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateNumbers(int updateNumber) {
        // remove all zombies
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < zombies.Length; i++)
        {
            Destroy(zombies[i]);
        }

        // remove all current arrows
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");

        for (int i = 0; i < arrows.Length; i++)
        {
            Destroy(arrows[i]);
        }

        string url = "http://192.81.208.150/updateNumbers/" + updateNumber;
		WWW www = new WWW (url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// always assume no errors
		var data = JSON.Parse (www.text);
		term1 = data ["term1"].AsInt;
		term2 = data ["term2"].AsInt;
		sum = data ["sum"].AsInt;

		int arrCount = data ["randoNums"].AsArray.Count;
		randomNum = new int[arrCount];
		for (int i = 0; i < arrCount; i++) {
			randomNum [i] = data ["randoNums"] [i].AsInt;
		}

        // call to spawn the zombies (include one more than the array count)!
        spawner.Spawn(arrCount + 1);
	}

	void print() {
		Debug.Log ("term1 " + term1);
		Debug.Log ("term2 " + term2);
		Debug.Log ("sum " + sum);

		string arr = "randoNums [ ";

		for (int i = 0; i < randomNum.GetLength(0); i++) {
			arr += randomNum [i] + " ";
		}
		arr += "]";

		Debug.Log (arr);
	}
}
