using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    public enum ResourceType { Meat, Plant, Liquid };
    public ResourceType resourceType = ResourceType.Meat;
    PlayerState playerState;

	// Use this for initialization
	void Start () {
        playerState = FindObjectOfType<PlayerState>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        GainResources();
        Destroy(gameObject);
    }

    void GainResources()
    {
        if (resourceType == ResourceType.Meat)
        {
            playerState.meat++;
        }
        else if (resourceType == ResourceType.Plant)
        {
            playerState.plants++;
        }
        else if (resourceType == ResourceType.Liquid)
        {
            playerState.liquids++;
        }
    }
}
