using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessFallingScript : MonoBehaviour {

    GameObject background;
    float spinFactor;
    float speedFactor;

	// Use this for initialization
	void Start ()
    {
        background = GameObject.Find("Background");
        spinFactor = Random.Range(1f, 8f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        speedFactor = GameObject.Find("Main Camera").GetComponent<EndlessDifficultyCalculator>().GetDifficulty();
        transform.Translate(new Vector3(0, -1 * background.GetComponent<EndlessBackdropScript>().speed * speedFactor * Time.deltaTime), Space.World);
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
