using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Attack : MonoBehaviour {

    // reference to health bar
    BarScript health;

    // update number handler
    UpdateNumberHandler updateNumHandler;

	// update score
	Score score;

    // Use this for initialization
    void Start () {
        updateNumHandler = GameObject.Find("/UpdateNumberHandler").GetComponent<UpdateNumberHandler>();
        health = GameObject.Find("/Canvas/Health Bar").GetComponent<BarScript>();
		score = GameObject.Find ("/Canvas/Score").GetComponent<Score>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(this.gameObject.transform.position.z >= ZombieSpawner.LENGTH_AWAY_FROM_CAMERA)
        {
            Destroy(this.gameObject);
        }
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Enemy") {
			// if correct zombie is checked
			if(Int32.Parse(other.gameObject.transform.Find("Body/Text").GetComponent<TextMesh>().text) == updateNumHandler.sum)
            {
				// find how many zombies are left
				GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
				score.UpdateScore(zombies.Length * 2);

                // call for new equation and zombies
                updateNumHandler.UpdateNumbers(UpdateNumberHandler.NUM_RAND_ZOMBIES);
                Debug.Log("Update Numbers from Attack!");
            }
            // penalize for getting the incorrect answer
            else
            {
                Destroy(other.gameObject);

                // damage player
                health.DamagePlayer();
            }

            Destroy(this.gameObject);
		}
	}
}
