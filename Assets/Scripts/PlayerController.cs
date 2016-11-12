using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Facebook.Unity;

public class PlayerController : MonoBehaviour {

   	public float movementSpeed = 5f;
    Rigidbody2D myRigidBody;
    Vector3 targetPosition;
    Vector3 movingVector;

	GridSquareState[] gridSquares;

    // Use this for iniialization
  
//    void Awake()
//    {
//        if (!FB.IsInitialized)
//        {
//            // Initialize the Facebook SDK
//            FB.Init(InitCallback, OnHideUnity);
//        }
//        else
//        {
//            // Already initialized, signal an app activation App Event
//            FB.ActivateApp();
//        }
//    }
//
//    private void InitCallback()
//    {
//        if (FB.IsInitialized)
//        {
//            // Signal an app activation App Event
//            FB.ActivateApp();
//            // Continue with Facebook SDK
//            //var perms = new List<string>() { "public_profile", "email", "user_friends" };
//            //FB.LogInWithReadPermissions(perms, AuthCallback);
//            FB.Mobile.AppInvite(
//                new Uri("https://fb.me/810530068992919"),
//                new Uri("http://i.imgur.com/zkYlB.jpg"),
//                AppInviteCallback
//            );
//            //FB.AppRequest(
//            //    "Come play this great game!",
//            //    null, null, null, null, null, null,
//            //    delegate (IAppRequestResult result) {
//            //        Debug.Log(result.RawResult);
//            //    }
//            //);
//
//            //FB.ShareLink(
//            //    new Uri("https://github.com/Abhishek-Biswas/SocialJam"),
//            //    callback: ShareCallback
//            //);
//            var tutParams = new Dictionary<string, object>();
//            tutParams[AppEventParameterName.ContentID] = "tutorial_step_1";
//            tutParams[AppEventParameterName.Description] = "First step in the tutorial, clicking the first button!";
//            tutParams[AppEventParameterName.Success] = "1";
//
//            FB.LogAppEvent(
//                AppEventName.CompletedTutorial,
//                parameters: tutParams
//            );
//            // ...
//        }
//        else
//        {
//            Debug.Log("Failed to Initialize the Facebook SDK");
//        }
//    }
//
//    private void AppInviteCallback(IAppInviteResult result)
//    {
//        throw new NotImplementedException();
//    }
//
//    private void OnHideUnity(bool isGameShown)
//    {
//        if (!isGameShown)
//        {
//            // Pause the game - we will need to hide
//            Time.timeScale = 0;
//        }
//        else
//        {
//            // Resume the game - we're getting focus again
//            Time.timeScale = 1;
//        }
//    }
//
//	private void ShareCallback(IShareResult result)
//    {
//        if (result.Cancelled || !String.IsNullOrEmpty(result.Error))
//        {
//            Debug.Log("ShareLink Error: " + result.Error);
//        }
//        else if (!String.IsNullOrEmpty(result.PostId))
//        {
//            // Print post identifier of the shared content
//            Debug.Log(result.PostId);
//        }
//        else
//        {
//            // Share succeeded without postID
//            Debug.Log("ShareLink success!");
//        }
//    }
//
//    private void AuthCallback(ILoginResult result)
//    {
//        if (FB.IsLoggedIn)
//        {
//            // AccessToken class will have session details
//            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
//            // Print current access token's User ID
//            Debug.Log(aToken.UserId);
//            // Print current access token's granted permissions
//            foreach (string perm in aToken.Permissions)
//            {
//                Debug.Log(perm);
//            }
//        }
//        else
//        {
//            Debug.Log("User cancelled login");
//        }
//    }

	// ========================================
	// Game loop
	// ========================================

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
		gridSquares = GameObject.FindObjectsOfType<GridSquareState>();
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

	// ========================================
	// Public manipulators
	// ========================================

	public GridSquareState GetCurrentSquare() {		
		foreach(GridSquareState state in gridSquares) {
			if (state.ContainsObject(gameObject)) {
				return state;
			}
		}
		return null;
	}

	// ========================================
	// Internal functions
	// ========================================


}
