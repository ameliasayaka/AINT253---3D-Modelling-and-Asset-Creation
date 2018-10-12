using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerScript : MonoBehaviour {

    public bool hasPlayerOpened;
    public bool isAlreadyOpen;
    private bool playerInRange;
    private Transform playerTransform;
    private Rigidbody playerRigidbody;
    private Animator monsterDoorAnimation;

    private AudioSource doorSquelchSound;

    [SerializeField]
    private float force = 3.0f;

    

	// Use this for initialization
	void Start () {
        hasPlayerOpened = false;
        isAlreadyOpen = false;
        playerInRange = false;
        doorSquelchSound = GetComponent<AudioSource>();
        monsterDoorAnimation = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerRigidbody = playerTransform.GetComponent<Rigidbody>();
	}

    private void OnTriggerEnter(Collider other)
    {

        playerInRange = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }

    // Update is called once per frame
    void Update () {
		if (playerInRange && !isAlreadyOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                hasPlayerOpened = true;
                monsterDoorAnimation.SetBool("hasPlayerOpened", hasPlayerOpened);
                isAlreadyOpen = true;
                doorSquelchSound.Play();
                playerRigidbody.AddForce(-playerTransform.forward * force, ForceMode.Impulse);
            }
 
        }
	}
}
