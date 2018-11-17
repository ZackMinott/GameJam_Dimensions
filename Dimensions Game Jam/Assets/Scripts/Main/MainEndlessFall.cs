using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEndlessFall : MonoBehaviour {

    GameObject background;

    // Use this for initialization
    void Start()
    {
        background = GameObject.Find("Background");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1 * background.GetComponent<BackdropScript>().speed * Time.deltaTime), Space.World);
        if (transform.position.y <= -5.5)
        {
            Object.Destroy(transform.gameObject);
        }
    }
}


