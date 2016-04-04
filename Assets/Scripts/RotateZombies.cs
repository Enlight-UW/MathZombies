using UnityEngine;
using System.Collections;

public class RotateZombies : MonoBehaviour {

    private Transform target;

    void Start()
    {
        target = GameObject.Find("/CardboardMain/Collision").transform;
    }

	void Awake() {
		
	}

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target 
        transform.LookAt(target);
    }

}
