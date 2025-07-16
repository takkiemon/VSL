using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSLPlayerController : MonoBehaviour
{

    private Rigidbody rigidBody;

    bool movingLeft;
    bool movingRight;
    bool movingUp;
    bool movingDown;

    private float playerSpeed = 0.1f;
    private float jumpForce = 350f;

    private bool isInSphere;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void ButtonInput(string input)
    {

        switch (input)
        {
            case "up":
                movingUp = true;
                break;
            case "un-up":
                movingUp = false;
                break;
            case "right":
                movingRight = true;
                break;
            case "un-right":
                movingRight = false;
                break;
            case "down":
                movingDown = true;
                break;
            case "un-down":
                movingDown = false;
                break;
            case "left":
                movingLeft = true;
                break;
            case "un-left":
                movingLeft = false;
                break;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (movingLeft && !movingRight)
        {
            rigidBody.MovePosition(rigidBody.position + new Vector3(-playerSpeed, 0, 0));
        }
        else if (!movingLeft && movingRight)
        {
            rigidBody.MovePosition(rigidBody.position + new Vector3(playerSpeed, 0, 0));
        }
        if (movingUp && !movingDown)
        {
            rigidBody.MovePosition(rigidBody.position + new Vector3(0, 0, playerSpeed));
        }
        else if (!movingUp && movingDown)
        {
            rigidBody.MovePosition(rigidBody.position + new Vector3(0, 0, -playerSpeed));
        }
    }

    //Track if the player capsule is currently inside the transparent sphere or not
    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "PlatformSphere")
        {
            isInSphere = true;
        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.tag == "PlatformSphere")
        {
            isInSphere = false;
        }
    }
}
