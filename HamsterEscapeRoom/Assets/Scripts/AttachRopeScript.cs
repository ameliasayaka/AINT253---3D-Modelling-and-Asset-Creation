using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachRopeScript : MonoBehaviour {
    public GameObject interactCanvas;
    public GameObject knot;
    private PlayerInventoryScript player;
    private bool isInRange;
    private bool isAttached;

    // Use this for initialization
    void Start () {
        isInRange = false;
        isAttached = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && isInRange &&!isAttached)
        {
            knot.SetActive(true);
            interactCanvas.SetActive(false);
            player.RemoveRope();
            isAttached = true;


            Debug.Log(player.RopeCounter);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isAttached && player.RopeCounter != 0)
        {
            interactCanvas.SetActive(true);
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactCanvas.SetActive(false);
            isInRange = false;
        }
    }
}
