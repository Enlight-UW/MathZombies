using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Attack : MonoBehaviour {

    // reference to health bar
    BarScript health;

    // update number handler
    UpdateNumberHandler updateNumHandler;

    // Use this for initialization
    void Start () {
        updateNumHandler = GameObject.Find("/UpdateNumberHandler").GetComponent<UpdateNumberHandler>();
        health = GameObject.Find("/Canvas/Health Bar").GetComponent<BarScript>();
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
			if(Int32.Parse(other.gameObject.transform.Find("Body/Text").GetComponent<TextMesh>().text) == updateNumHandler.sum)
            {
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
