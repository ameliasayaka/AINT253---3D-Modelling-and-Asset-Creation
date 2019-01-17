using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour {
    private PlayerInventoryScript player;
    private bool isInRange;

    private Animator animator;
    private AudioSource wheelAudio;

    public GameObject interactCanvas;
    public GameObject door;

    private AudioSource doorNoise;
    private Animator doorAnimator;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryScript>();
        wheelAudio = GetComponent<AudioSource>();
        doorNoise = door.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
        doorAnimator = door.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            interactCanvas.SetActive(false);
            animator.SetBool("isSpin", true);
            wheelAudio.Play();
            doorNoise.Play();
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
