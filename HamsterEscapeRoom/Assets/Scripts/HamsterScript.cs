using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterScript : MonoBehaviour {
    public GameObject interactCanvas;
    public GameObject hamsterCanvas;
    private PlayerInventoryScript playerScript;
    private Animator hamsterAnimator;
    private AudioSource hamsterSqueakAudio;
   

    private bool isInRange;
    private bool isFed;

    // Use this for initialization
    void Start () {
        isInRange = false;
        isFed = false;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryScript>();
        hamsterAnimator = GetComponent<Animator>();
        hamsterSqueakAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (!isFed && isInRange && (playerScript.FoodCounter == 15))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerScript.RemoveFood();
                isFed = true;
                hamsterAnimator.SetBool("isFed", true);
                interactCanvas.SetActive(false);
                hamsterCanvas.SetActive(false);
            }

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!isFed)
            {
                interactCanvas.SetActive(true);
                hamsterCanvas.SetActive(true);
                isInRange = true;
                hamsterSqueakAudio.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isFed)
            {
                interactCanvas.SetActive(false);
                hamsterCanvas.SetActive(false);
                isInRange = false;
            }
        }
    }
}
