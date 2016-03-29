using UnityEngine;
using System.Collections;

public class ProjectileManager : MonoBehaviour {

	float timer;
	public float timeBetweenBullets;
	public GameObject projectile;
	public Transform spawn;

	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets)
		{
			Shoot ();
		}
	}

	void Shoot(){
		Instantiate (projectile, spawn.position, spawn.rotation);
		timer = 0f;
	}
}
