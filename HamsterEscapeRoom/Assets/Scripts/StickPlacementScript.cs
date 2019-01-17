using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPlacementScript : MonoBehaviour {
    public GameObject interactCanvas;
    public GameObject stickPile;
    private bool isInRange;
    private PlayerInventoryScript player;
	// Use this for initialization
	void Start () {
        isInRange = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.RemoveStick();
                stickPile.SetActive(true);
                interactCanvas.SetActive(false);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && player.StickCounter == 5)
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
