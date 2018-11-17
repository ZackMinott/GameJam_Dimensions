using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    public float asteroidSpawnBaseTime = 3f;
    public float coinSpawnBaseTime = 4f;

    float asteroidSpawnWaitTime;
    float coinSpawnWaitTime;
    float nextAsteroidSpawnTime;
    float nextCoinSpawnTime;
    float speedFactor;

    public GameObject redAsteroid1;
    public GameObject redAsteroid2;
    public GameObject blueAsteroid1;
    public GameObject blueAsteroid2;
    public GameObject coin;

	
	// Update is called once per frame
	void Update ()
    {
        speedFactor = GameObject.Find("Main Camera").GetComponent<EndlessDifficultyCalculator>().GetDifficulty();


        asteroidSpawnWaitTime = asteroidSpawnBaseTime / speedFactor;
        coinSpawnWaitTime = coinSpawnBaseTime / speedFactor;

        if (Time.time >= nextAsteroidSpawnTime)
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
            nextAsteroidSpawnTime = Time.time + asteroidSpawnWaitTime;
        }
        if (Time.time >= nextCoinSpawnTime)
        {
            Instantiate(coin, new Vector3(Random.Range(-(transform.position.x), transform.position.x) + transform.position.x, transform.position.y), new Quaternion(transform.rotation.x, transform.rotation.y, Random.rotation.z, transform.rotation.w));
            nextCoinSpawnTime = Time.time + coinSpawnWaitTime;
        }
	}
}
