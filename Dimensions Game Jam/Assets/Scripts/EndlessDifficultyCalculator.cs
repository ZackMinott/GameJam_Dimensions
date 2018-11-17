using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessDifficultyCalculator : MonoBehaviour {

    [Range(1,3)]
    public int difficultyFactor = 1;
    float difficultyWaitTime;
    float nextDifficultyStart = 3;
    float currentDifficultyProgress = 0;
    int difficultyBenchmark = 1;
    public AudioSource music;


	// Use this for initialization
	void Start ()
    {
        difficultyWaitTime = 30 / difficultyFactor;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > nextDifficultyStart)
        {
            if (currentDifficultyProgress <= 1)
            {
                currentDifficultyProgress += .1f * Time.deltaTime;
            }
            else if(currentDifficultyProgress >= 1)
            {
                nextDifficultyStart = Time.time + difficultyWaitTime;
                currentDifficultyProgress = 0;
                difficultyBenchmark++;
            }
        }
        music.pitch = 1 + (GetDifficulty() -1)/10;
	}

    public float GetDifficulty()
    {
        float totalDifficulty = difficultyBenchmark * difficultyFactor + difficultyFactor * currentDifficultyProgress;
        return totalDifficulty < 30 ? totalDifficulty : 30;
    }
}
