﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // movement variables
   public float movementSpeed = 5f;
    Vector3 targetPosition;
    Vector3 movingVector;
    Rigidbody2D myRigidBody;


    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse input
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z;
        }

        // Touch Input
        if (Input.touchCount > 0)
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
}