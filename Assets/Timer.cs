using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    int minutes;
    public int resetIntervalMinutes;
    public bool waitingToReset = true;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        System.DateTime myTime = System.DateTime.Now;
        minutes = myTime.Minute;
        if (minutes % resetIntervalMinutes == 0 && waitingToReset)
        {
            // Call reset function
            waitingToReset = false;
        }
        else if (minutes % resetIntervalMinutes != 0 && waitingToReset == false)
        {
            waitingToReset = true;
        }

    }
}
