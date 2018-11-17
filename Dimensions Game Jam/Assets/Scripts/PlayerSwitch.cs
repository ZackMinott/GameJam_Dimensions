using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSwitch : MonoBehaviour {
    GameObject player1;
    GameObject player2;

    GameObject portal_1;
    GameObject portal_2;

    Animator switching1;
    Animator switching2;

    Animator portal1;
    Animator portal2;

    public AudioSource noise;
    public bool inTheMiddle = false;
	// Use this for initialization
	void Start () {
        player1 = GameObject.FindGameObjectWithTag("Red");
        player2 = GameObject.FindGameObjectWithTag("Blue");

        //portal_1 = GameObject.FindGameObjectWithTag("portal1");
        //portal_2 = GameObject.FindGameObjectWithTag("portal2");

        switching1 = player1.GetComponent<Animator>();
        switching2 = player2.GetComponent<Animator>();

        //portal1 = portal_1.GetComponent<Animator>();
        //portal2 = portal_2.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && inTheMiddle == false)
        {
            StartCoroutine("switchAnimation");
            noise.Play();
        }
	}
    private void OnCollissionEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "LimitingWall")
        {
            inTheMiddle = true;
        }
    }
    void Switch()
    {
        
        Vector3 temp = player1.transform.position;
        player1.transform.position = player2.transform.position;
        player2.transform.position = temp;
    }

    IEnumerator switchAnimation()
    {
        Debug.Log("Space");
        //portal_1.SetActive(true);
        //portal_2.SetActive(true);

        switching1.SetBool("isSwitching", true);
        switching2.SetBool("isSwitching", true);
        //portal1.SetBool("isSwitching", true);
        //portal2.SetBool("isSwitching", true);
        yield return new WaitForSeconds(.2f);

        Switch();

        yield return new WaitForSeconds(.1f);
        switching1.SetBool("isSwitching", false);
        switching2.SetBool("isSwitching", false);
        //portal1.SetBool("isSwitching", false);
        //portal2.SetBool("isSwitching", false);

        //portal_1.SetActive(false);
        //portal_2.SetActive(false);


    }
}
