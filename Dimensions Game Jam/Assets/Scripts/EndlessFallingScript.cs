using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessFallingScript : MonoBehaviour {

    GameObject background;
    float spinFactor;

	// Use this for initialization
	void Start ()
    {
        background = GameObject.Find("Background");
        spinFactor = Random.Range(1f, 8f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(0, -1 * background.GetComponent<BackdropScript>().speed * Time.deltaTime), Space.World);
        if (!(transform.gameObject.tag == "Coin"))
        {
            transform.Rotate(new Vector3(0, 0, spinFactor));
        }
        if (transform.position.y <= -6)
        {
            Object.Destroy(transform.gameObject);
        }
	}
}
