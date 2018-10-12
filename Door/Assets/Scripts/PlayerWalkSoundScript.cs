using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSoundScript : MonoBehaviour {


    private AudioSource playerWalkSound;
    private Rigidbody playerObject;

    [SerializeField]
    private AudioClip tatamiWalk;
    private AudioClip meatWalk;

	// Use this for initialization
	void Start () {
        playerWalkSound = GetComponent<AudioSource>();
        playerObject = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
     
		
	}
}
