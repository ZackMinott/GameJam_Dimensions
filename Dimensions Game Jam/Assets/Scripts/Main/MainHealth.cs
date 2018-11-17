using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainHealth : MonoBehaviour {

    public Image[] HealthPips;
    public Sprite fullPip;
    public Sprite emptyPip;

    [Range(0, 5)] public int currentHearts = 5;


    PlayerController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<PlayerController>();
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(controller.lives);
        for (int i = 0; i < HealthPips.Length; i++)
        {
            if (i < controller.lives)
            {
                HealthPips[i].sprite = fullPip;
            } else
            {
                HealthPips[i].sprite = emptyPip;
            }

            if(i < currentHearts)
            {
                HealthPips[i].enabled = true;
            }else
            {
                HealthPips[i].enabled = false;
            }
        }
	}
}
