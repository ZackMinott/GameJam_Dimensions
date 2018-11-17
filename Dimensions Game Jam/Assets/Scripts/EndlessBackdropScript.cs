using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackdropScript : MonoBehaviour {

    public float speed;
    float difficulty;

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(transform.position.x, (transform.localScale.y - 10)/10 * 5, transform.position.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        difficulty = GameObject.Find("Main Camera").GetComponent<EndlessDifficultyCalculator>().GetDifficulty();
        speed = difficulty < 10? difficulty : 10;
        if (transform.position.y <= (transform.localScale.y - 10) / 10 * -5 + (speed/30))
        {
            transform.position = new Vector3(transform.position.x, (transform.localScale.y - 10) / 10 * 5, transform.position.z);
        }
        transform.Translate(new Vector3(0, -1 * speed * Time.deltaTime));
	}

}
