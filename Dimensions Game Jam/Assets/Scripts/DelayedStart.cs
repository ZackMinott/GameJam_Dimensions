using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{
    //this will be the one that will put onhold
    public GameObject PauseThis;
    //put numbers / counters here
    public GameObject CountDown;


    // Use this for initialization
    void Start()
    {
        StartCoroutine("StartDelay");

    }

    /*  public void Update()
      {
          if (Input.GetButtonDown("Horizontal") && goPlayEnd == true)
          {
              FFFormBox.SetActive(false);

              FFEnd.SetActive(true);
              Normal.SetActive(true);
              Shadow.SetActive(false);
              FFLight.SetActive(false);
          }

      }*/

    IEnumerator StartDelay()
    {

        yield return new WaitForSeconds(3);
        Debug.Log("waited");
        //CountDown.SetActive(false);
        //PauseThis.SetActive(true);

    }
    /* public void PlayIdle()
     {
         FFFormBox.SetActive(true);

         Shadow.SetActive(true);
         Normal.SetActive(false);
         FFLight.SetActive(true);
         StartCoroutine("FFFormBoxDelay");
     }*/

    /* IEnumerator FFFormBoxDelay()
     {
         yield return new WaitForSeconds(1);
         PlayerController.GetComponent<Player1>().enabled = true;
         goPlayEnd = true;
     }*/

}
