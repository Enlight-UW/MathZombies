using UnityEngine;
using System.Collections;

public class ProjectileAI : MonoBehaviour {

	public float speed = 500f;
	public float timer = 0f;
	public float rotation = 750f;

	// Use this for initialization
	void Awake () {
		GetComponent<Rigidbody>().AddForce(gameObject.transform.up * speed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.fixedDeltaTime;
		if (timer >= 30f) {
			Destroy(gameObject);
		}
		transform.Rotate (Vector3.up * Time.fixedDeltaTime * rotation);
	}
}
