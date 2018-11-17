using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    public float spawnWaitTime = 0.5f;
    float nextSpawnTime;

    public GameObject redAsteroid1;
    public GameObject redAsteroid2;
    public GameObject blueAsteroid1;
    public GameObject blueAsteroid2;
    public GameObject background;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time >= nextSpawnTime)
        {
            bool selectRed = Random.Range(0f, 1f) < 1f/2;
            bool selectOne = Random.Range(0f, 1f) < 1f / 2;
            if (selectRed)
            {
                if (selectOne)
                {
                    Instantiate(redAsteroid1, new Vector3(Random.Range(-(transform.position.x), transform.position.x) + transform.position.x, transform.position.y), new Quaternion(transform.rotation.x, transform.rotation.y, Random.rotation.z, transform.rotation.w));
                }
                else if (!selectOne)
                {
                    Instantiate(redAsteroid2, new Vector3(Random.Range(-(transform.position.x), transform.position.x) + transform.position.x, transform.position.y), new Quaternion(transform.rotation.x, transform.rotation.y, Random.rotation.z, transform.rotation.w));
                }
            }
            else if (!selectRed)
            {
                if (selectOne)
                {
                    Instantiate(blueAsteroid1, new Vector3(Random.Range(-(transform.position.x), transform.position.x) + transform.position.x, transform.position.y), new Quaternion(transform.rotation.x, transform.rotation.y, Random.rotation.z, transform.rotation.w));
                }
                else if (!selectOne)
                {
                    Instantiate(blueAsteroid2, new Vector3(Random.Range(-(transform.position.x), transform.position.x) + transform.position.x, transform.position.y), new Quaternion(transform.rotation.x, transform.rotation.y, Random.rotation.z, transform.rotation.w));
                }
                
            }
            nextSpawnTime = Time.time + spawnWaitTime;
        }
	}
}
