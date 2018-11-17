using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{
    //this will be the one that will put onhold
    public GameObject PauseThis;
    //put numbers / counters here
    public GameObject Three;
    public GameObject Two;
    public GameObject One;
    public GameObject BG;
    bool goPlay = false;


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

        yield return new WaitForSeconds(1);
        Three.SetActive(false);
        Two.SetActive(true);
        StartCoroutine("OneCT");
        
        //CountDown.SetActive(false);
        //PauseThis.SetActive(true);

    }
    IEnumerator OneCT()
    {
        yield return new WaitForSeconds(1);
        Two.SetActive(false);
        One.SetActive(true);
        StartCoroutine("ReadyPlay");
    }
    IEnumerator ReadyPlay()
    {
        yield return new WaitForSeconds(1);
        One.SetActive(false);
        if (BG.GetComponent<BackdropScript>() != null)
        {
            BG.GetComponent<BackdropScript>().enabled = true;
        }
        else
        {
            BG.GetComponent<EndlessBackdropScript>().enabled = true;
        }
    }

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
