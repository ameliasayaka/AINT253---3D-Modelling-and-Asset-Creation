using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour {
    private PlayerInventoryScript player;
    private bool isInRange;
    private bool stringAttached;
    private Animator animator;
    public GameObject interactCanvas;
    public GameObject door;

    private Animator doorAnimator;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryScript>();
        stringAttached = false;
        animator = gameObject.GetComponent<Animator>();
        doorAnimator = door.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            interactCanvas.SetActive(false);
            animator.SetBool("isSpin", true);
            doorAnimator.SetBool("isDoorOpen", true);

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && player.RopeColleted == true && player.RopeCounter == 0)
        {
            isInRange = true;
            interactCanvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isInRange = false;
            interactCanvas.SetActive(false);
        }
    }
}
