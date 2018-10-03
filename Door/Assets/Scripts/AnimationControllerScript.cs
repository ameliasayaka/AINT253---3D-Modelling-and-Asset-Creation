using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerScript : MonoBehaviour {

    public bool hasPlayerOpened;
    public bool isAlreadyOpen;
    private bool playerInRange;
    private Animator monsterDoorAnimation;

    

	// Use this for initialization
	void Start () {
        hasPlayerOpened = false;
        isAlreadyOpen = false;
        playerInRange = false;
        monsterDoorAnimation = GetComponent<Animator>();
	}

    private void OnTriggerStay(Collider other)
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
                monsterDoorAnimation.SetBool("hasPlayerOpened", hasPlayerOpened);
                isAlreadyOpen = true;
            }
 
        }
	}
}
