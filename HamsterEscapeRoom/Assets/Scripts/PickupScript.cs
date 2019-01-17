using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {
    public GameObject interactCanvas;
    private PlayerInventoryScript playerScript;

    public string pickUpType;

    private bool isInRange;
	// Use this for initialization
	void Start () {
        isInRange = false;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            if(pickUpType == "Food")
            {
                playerScript.AddFood();
            }
            else if (pickUpType == "Stick")
            {
                playerScript.AddStick();
            }
            else if (pickUpType == "Rope")
            {
                playerScript.AddRope();
            }
            interactCanvas.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
