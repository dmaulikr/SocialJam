using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // movement variables
    public float movementSpeed = 5f;
    Rigidbody2D myRigidBody;
    Vector3 targetPosition;
    Vector3 movingVector;
    public float borderWidthX;
    public float borderWidthY;

    // Use this for iniialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse input
        if (Input.GetMouseButton(0) && IsWithinScreenBounds(Input.mousePosition))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z;
        }

        // Touch Input
        if (Input.touchCount > 0 && IsWithinScreenBounds(Input.GetTouch(0).position))
        {
            targetPosition = targetPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            targetPosition.z = transform.position.z;
        }


        if (targetPosition != transform.position)
        {
            movingVector = (targetPosition - transform.position) * movementSpeed;
            myRigidBody.velocity = movingVector;
        }
        else
        {
            myRigidBody.velocity = Vector3.zero;
        }
    }

    bool IsWithinScreenBounds(Vector2 screenCoordinate)
    {
        if (screenCoordinate.x > borderWidthX && screenCoordinate.x < Screen.width - borderWidthX)
        {
            if (screenCoordinate.y > borderWidthY && screenCoordinate.y < Screen.height - borderWidthY)
            {
                return true;
            }
        }
        return false;
    }
}
