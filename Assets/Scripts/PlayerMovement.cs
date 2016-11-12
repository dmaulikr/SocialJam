using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    // movement variables
    public float movementSpeed = 5f;
    Rigidbody2D myRigidBody;
    Vector3 targetPosition;
    Vector3 movingVector;
    public enum BorderMode { absolutePixels, uiPosition};
    public BorderMode borderMode = BorderMode.absolutePixels;
    public float borderWidthPixelsX;
    public float borderWidthPixelsY;
    public RectTransform BorderTopLefttUiPosition;
    public RectTransform BorderBottomRightUiPosition;


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
        if (borderMode == BorderMode.absolutePixels)
        {
            if (screenCoordinate.x > borderWidthPixelsX && screenCoordinate.x < Screen.width - borderWidthPixelsX)
            {
                if (screenCoordinate.y > borderWidthPixelsY && screenCoordinate.y < Screen.height - borderWidthPixelsY)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            if (screenCoordinate.x > BorderTopLefttUiPosition.position.x && screenCoordinate.x > BorderTopLefttUiPosition.position.y)
            {
                if (screenCoordinate.x < BorderBottomRightUiPosition.position.x && screenCoordinate.y < BorderBottomRightUiPosition.position.y)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
