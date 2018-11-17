using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyControl : MonoBehaviour {

    public static float difficulty = 1;

    public void SetDifficulty(float _difficulty)
    {
        difficulty = _difficulty;
    }
}
