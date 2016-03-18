using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour {

    public Transform target;
    public float speed = 2;
   
    // Update is called once per frame
    void Update() {
        float step = speed * Time.deltaTime;

        Vector3 target = new Vector3(0, 0, 0);
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        /*
        if (transform.position == target)
        {
            // call health down function
            Destroy(gameObject);
            return;
        }
        */

    }

}
