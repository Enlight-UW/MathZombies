using UnityEngine;
using System.Collections;

public class ZombieCollision : MonoBehaviour {

    // reference to health bar
    BarScript health;

    // update number handler
    UpdateNumberHandler updateNumHandler;

    // Use this for initialization
    void Start () {
        updateNumHandler = GameObject.Find("/UpdateNumberHandler").GetComponent<UpdateNumberHandler>();
        health = GameObject.Find("/CardboardMain/Head/Canvas/Health Bar").GetComponent<BarScript>();
    }
		
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
        {
            // now spawn again
            updateNumHandler.UpdateNumbers(UpdateNumberHandler.NUM_RAND_ZOMBIES);
            Debug.Log("Update Numbers from zombie collision!");

            // damage player
            health.DamagePlayer();
        }
	}
}
