using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSLPlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
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
        StartCoroutine(Shoot());
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

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward * .5f, Quaternion.identity);
            yield return new WaitForSeconds(2f); // Delay between shots
        }
    }
}
