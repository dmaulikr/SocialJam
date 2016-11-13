using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Facebook.Unity;

public class FacbookIntegration : MonoBehaviour {

    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            //var perms = new List<string>() { "public_profile", "email", "user_friends" };
            //FB.LogInWithReadPermissions(perms, AuthCallback);
            //FB.Mobile.AppInvite(
            //    new Uri("https://fb.me/810530068992919"),
            //    new Uri("http://i.imgur.com/zkYlB.jpg"),
            //    AppInviteCallback
            //);
            EmptyAppRequest();
            //FB.ShareLink(
            //    new Uri("https://github.com/Abhishek-Biswas/SocialJam"),
            //    callback: ShareCallback
            //);
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    public void EmptyAppRequest()
    {
        FB.AppRequest(
            "Come play this great game!",
            null, null, null, null, null, null,
            delegate (IAppRequestResult result)
            {
                Debug.Log(result.RawResult);
            }
        );
        var tutParams = new Dictionary<string, object>();
        tutParams[AppEventParameterName.ContentID] = "Friend_Request";
        tutParams[AppEventParameterName.Description] = "The player has shared the game with a friend";
        tutParams[AppEventParameterName.Success] = "1";

        FB.LogAppEvent(
            AppEventName.CompletedTutorial,
            parameters: tutParams
        );
    }

    private void AppInviteCallback(IAppInviteResult result)
    {
        throw new NotImplementedException();
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    private void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !String.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error: " + result.Error);
        }
        else if (!String.IsNullOrEmpty(result.PostId))
        {
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        }
        else
        {
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
        }
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
