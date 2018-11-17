using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdropScript : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(transform.position.x, (transform.localScale.y - 10)/10 * 5, transform.position.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y <= (transform.localScale.y - 10) / 10 * -5 + (speed/30))
        {
            transform.position = new Vector3(transform.position.x, (transform.localScale.y - 10) / 10 * 5, transform.position.z);
        }
        transform.Translate(new Vector3(0, -1 * speed * Time.deltaTime));
	}
}
