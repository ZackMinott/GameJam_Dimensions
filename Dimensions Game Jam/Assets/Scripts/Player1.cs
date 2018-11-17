using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player1 : MonoBehaviour {

    float accelerationTimeAirborne = .2f;
    float moveSpeed = 6;

    Vector3 velocity;
    float velocityXSmoothing;
    float velocityYSmoothing;

    PlayerController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        float targetVelocityX = input.x * moveSpeed;
        float targetVelocityY = input.y * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTimeAirborne);
        velocity.y = Mathf.SmoothDamp(velocity.y, targetVelocityY, ref velocityYSmoothing, accelerationTimeAirborne);

        controller.Move(velocity * Time.deltaTime);
    }
}
